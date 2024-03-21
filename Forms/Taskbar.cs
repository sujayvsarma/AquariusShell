using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using AquariusShell.ConfigurationManagement;
using AquariusShell.ConfigurationManagement.Constants;
using AquariusShell.ConfigurationManagement.Settings;
using AquariusShell.Modules;
using AquariusShell.Properties;
using AquariusShell.Runtime;

namespace AquariusShell.Forms
{
    /// <summary>
    /// The horizontal taskbar at the bottom of the screen. Ideally this should be moveable to anywhere else 
    /// just like it was with Windows 95.
    /// </summary>
    public partial class Taskbar : Form
    {

        /// <summary>
        /// Create the start button or move it to the right location
        /// </summary>
        private void CreateOrUpdateStartButton()
        {
            if (startButton == null)
            {
                startButton = new()
                {
                    Name = "startButton",
                    BackColor = _settings.BackgroundColour,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = _settings.TextColour,
                    Location = new(1, 1),
                    Size = new(TaskbarButtonSizes, TaskbarButtonSizes),
                    UseCompatibleTextRendering = false,
                    UseVisualStyleBackColor = false,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    TextImageRelation = TextImageRelation.Overlay
                };

                startButton.FlatAppearance.BorderColor = _settings.BackgroundColour;
                startButton.FlatAppearance.BorderSize = 1;

                startButton.Click += StartButtonClicked;
                this.Controls.Add(startButton);
            }

            if (_settings.ShowCaptions)
            {
                startButton.Font = new("Segoe UI", 8, FontStyle.Regular, GraphicsUnit.Point);
                startButton.Text = "Start";
                startButton.TextImageRelation = TextImageRelation.ImageAboveText;
                startButton.Height = TaskbarButtonSizes + 24;
                startButton.Width = TaskbarButtonSizes + 24;
            }

            startButton.Location = new(1, 1);
            startButton.Image = new Bitmap(Resources.windows_logo, ShellEnvironment.ConfiguredSizeOfIconsInPixels, ShellEnvironment.ConfiguredSizeOfIconsInPixels);
        }

        /// <summary>
        /// Create, update or remove the tasklist button as appropriate
        /// </summary>
        private void CreateUpdateOrRemoveTasklistButton()
        {
            if (_settings.ShowTaskSwitcherButton)
            {
                if (taskListButton == null)
                {
                    taskListButton = new()
                    {
                        Anchor = AnchorStyles.None,
                        FlatStyle = FlatStyle.Flat,
                        BackColor = _settings.BackgroundColour,
                        ForeColor = _settings.TextColour,
                        Name = "taskListButton",
                        Size = new Size(TaskbarButtonSizes, TaskbarButtonSizes),
                        UseCompatibleTextRendering = true,
                        UseVisualStyleBackColor = false,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        TextImageRelation = TextImageRelation.Overlay
                    };

                    taskListButton.FlatAppearance.BorderColor = _settings.BackgroundColour;
                    taskListButton.FlatAppearance.BorderSize = 1;

                    taskListButton.Click += TaskListButtonClicked;
                    this.Controls.Add(taskListButton);
                }

                // startButton is guaranteed to be always present
                switch (_settings.Location)
                {
                    case TaskbarPositionsEnum.Top:
                    case TaskbarPositionsEnum.Bottom:
                        taskListButton.Location = new Point(startButton!.Location.X + startButton.Size.Width + ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS, 1);
                        break;

                    case TaskbarPositionsEnum.Right:
                    case TaskbarPositionsEnum.Left:
                        taskListButton.Location = new Point(1, startButton!.Location.Y + startButton.Size.Height + ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS);
                        break;
                }

                Icon? icon = Icon.ExtractIcon(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe"), 16);
                if (icon != null)
                {
                    Bitmap bmp = new(icon.ToBitmap(), ShellEnvironment.ConfiguredSizeOfIconsInPixels, ShellEnvironment.ConfiguredSizeOfIconsInPixels);
                    taskListButton.Image = bmp;
                }

                if (_settings.ShowCaptions)
                {
                    taskListButton.Font = new("Segoe UI", 8, FontStyle.Regular, GraphicsUnit.Point);
                    taskListButton.Text = "Tasks";
                    taskListButton.TextImageRelation = TextImageRelation.ImageAboveText;
                    taskListButton.Height = TaskbarButtonSizes + 24;
                    taskListButton.Width = TaskbarButtonSizes + 24;
                }
            }
            else
            {
                if (taskListButton != null)
                {
                    this.Controls.Remove(taskListButton);
                    taskListButton = null;
                }
            }
        }

        /// <summary>
        /// Add or remove the clock
        /// </summary>
        private void CreateOrRemoveClock()
        {
            if (_settings.ShowClock)
            {
                if (clock == null)
                {
                    clockLabel = new()
                    {
                        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right,
                        Name = "clockLabel",
                        Padding = new(6),
                        Size = new(164, TaskbarButtonSizes),
                        Text = DateTime.Now.ToString(_settings.ClockDisplayFormat),
                        TextAlign = ContentAlignment.MiddleRight,
                        Dock = DockStyle.Right
                    };
                    this.Controls.Add(clockLabel);

                    clock = new()
                    {
                        Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds
                    };
                    clock.Tick += OnClockTimerTickEvent;
                    clock.Enabled = true;
                    clock.Start();
                }
            }
            else
            {
                if (clock != null)
                {
                    this.Controls.Remove(this.Controls["clockLabel"]);
                    clockLabel = null;

                    clock.Tick -= OnClockTimerTickEvent;
                    clock = null;
                }
            }
        }

        /// <summary>
        /// Create additional buttons. They are always removed and then added back
        /// </summary>
        private void CreateAdditionalButtons()
        {
            if (_settings.ShowAdditionalButtons && (_additionalButtonSettings != null))
            {
                foreach (Button btn in additionalButtons)
                {
                    this.Controls.Remove(btn);
                }

                int x = 1, y = 1;
                switch (_settings.Location)
                {
                    case TaskbarPositionsEnum.Top:
                    case TaskbarPositionsEnum.Bottom:
                        x = (_settings.ShowTaskSwitcherButton ? (taskListButton!.Location.X + taskListButton.Size.Width) : (startButton!.Location.X + startButton.Size.Width))
                                    + ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS;
                        break;

                    case TaskbarPositionsEnum.Left:
                    case TaskbarPositionsEnum.Right:
                        y = (_settings.ShowTaskSwitcherButton ? (taskListButton!.Location.Y + taskListButton.Size.Height) : (startButton!.Location.Y + startButton.Size.Height))
                                    + ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS;
                        break;
                }

                foreach (string buttonKey in _additionalButtonSettings.CustomButtons.Keys)
                {
                    CustomButtonSettings customButton = _additionalButtonSettings.CustomButtons[buttonKey];
                    Button button = new()
                    {
                        BackColor = _settings.BackgroundColour,
                        ForeColor = _settings.TextColour,
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point(x, y),
                        Size = new Size(TaskbarButtonSizes, TaskbarButtonSizes),
                        UseCompatibleTextRendering = true,
                        UseVisualStyleBackColor = false,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        TextImageRelation = TextImageRelation.Overlay,

                        Tag = customButton.Command
                    };

                    button.FlatAppearance.BorderColor = _settings.BackgroundColour;
                    button.FlatAppearance.BorderSize = 1;

                    bool hasIcon = (!string.IsNullOrWhiteSpace(customButton.IconPath));
                    bool hasCaptionAndShowingCaption = _settings.ShowCaptions && (!string.IsNullOrWhiteSpace(customButton.Caption));

                    if (hasIcon)
                    {
                        Bitmap bmp = new(customButton.IconPath!);
                        bmp = new Bitmap(bmp, ShellEnvironment.ConfiguredSizeOfIconsInPixels, ShellEnvironment.ConfiguredSizeOfIconsInPixels);
                        button.Image = bmp;
                    }

                    if (hasCaptionAndShowingCaption)
                    {
                        button.Font = new("Segoe UI", 8, FontStyle.Regular, GraphicsUnit.Point);
                        button.Text = customButton.Caption;
                        button.Height = TaskbarButtonSizes + 24;
                        button.Width = TaskbarButtonSizes + 24;

                        if (hasIcon)
                        {
                            button.TextImageRelation = TextImageRelation.ImageAboveText;
                        }
                    }

                    button.Click += TaskbarCustomButton_Click;
                    this.Controls.Add(button);

                    switch (_settings.Location)
                    {
                        case TaskbarPositionsEnum.Top:
                        case TaskbarPositionsEnum.Bottom:
                            x = button.Location.X + button.Size.Width + ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS;
                            break;

                        case TaskbarPositionsEnum.Left:
                        case TaskbarPositionsEnum.Right:
                            y = button.Location.Y + button.Size.Height + ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Set this form's size and location
        /// </summary>
        private void SetFormSizeAndLocation()
        {
            Point newLocation = new();
            Size newSize = new();

            if ((_settings.Location == TaskbarPositionsEnum.Top) || (_settings.Location == TaskbarPositionsEnum.Bottom))
            {
                newSize.Width = ShellEnvironment.PrimaryScreenSafe.Bounds.Width;
                newSize.Height = TaskbarButtonSizes + ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS;

                newLocation.X = 0;
            }
            else if ((_settings.Location == TaskbarPositionsEnum.Right) || (_settings.Location == TaskbarPositionsEnum.Left))
            {
                newSize.Width = TaskbarButtonSizes + ShellEnvironment.FORM_CONTROLS_MARGIN_EXTENTS;
                newSize.Height = ShellEnvironment.PrimaryScreenSafe.Bounds.Height;

                newLocation.Y = 0;

                // We cannot show the clock in Left or Right orientations!
                _settings.ShowClock = false;
            }

            if (_settings.ShowCaptions)
            {
                newSize.Height += 24;
            }

            switch (_settings.Location)
            {
                case TaskbarPositionsEnum.Top:
                    newLocation.Y = 0;
                    break;

                case TaskbarPositionsEnum.Bottom:
                    newLocation.Y = ShellEnvironment.PrimaryScreenSafe.Bounds.Height - newSize.Height;
                    break;

                case TaskbarPositionsEnum.Right:
                    newLocation.X = ShellEnvironment.PrimaryScreenSafe.Bounds.Width - newSize.Width;
                    break;

                case TaskbarPositionsEnum.Left:
                    newLocation.X = 0;
                    break;
            }

            this.Location = newLocation;
            this.Size = newSize;
            this.BackColor = _settings.BackgroundColour;
            this.ForeColor = _settings.TextColour;

            ShellEnvironment.TaskbarBounds = new(newLocation.X, newLocation.Y, newSize.Width, newSize.Height);
        }


        /// <summary>
        /// Set the position of the taskbar
        /// </summary>
        private void ApplyTaskbarSettings()
        {
            SetFormSizeAndLocation();            
            CreateOrUpdateStartButton();
            CreateUpdateOrRemoveTasklistButton();
            CreateOrRemoveClock();
            CreateAdditionalButtons();
        }

        /// <summary>
        /// Configuration changed
        /// </summary>
        /// <param name="updatedSettings">Copy of updated settings</param>
        private void ConfigurationProvider_ConfigurationUpdated(IAquariusShellSettings updatedSettings)
        {
            _settings = (TaskbarSettings)updatedSettings;
            if (_settings.ShowAdditionalButtons)
            {
                _additionalButtonSettings = ConfigurationProvider<TaskbarAdditionalButtonsSettings>.Get();
            }
            else
            {
                _additionalButtonSettings = null;
            }

            ApplyTaskbarSettings();
        }

        /// <summary>
        /// Dragging something onto the taskbar. We allow programs/files to be opened or launched this way!
        /// </summary>
        private void Taskbar_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string? path = ((string[]?)e.Data.GetData(DataFormats.FileDrop))?[0];
                if (!string.IsNullOrWhiteSpace(path))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        /// <summary>
        /// Dropping something onto the taskbar. Open/launch the program or file if we can
        /// </summary>
        private void Taskbar_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.Data != null) && (e.Effect == DragDropEffects.Copy))
            {
                string? path = ((string[]?)e.Data.GetData(DataFormats.FileDrop))?[0];
                if (!string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        Shell32.ExecuteOrLaunchTarget(path);
                    }
                }
            }
        }

        /// <summary>
        /// A timer tick. Do the clock thing!
        /// </summary>
        private void OnClockTimerTickEvent(object? sender, EventArgs e)
        {
            // If the timer is fired, then the clockLabel exists.
            clockLabel!.Text = DateTime.Now.ToString(_settings.ClockDisplayFormat);
        }

        /// <summary>
        /// The "task list" button was clicked. Show the list of running tasks. (ALT+TAB)
        /// </summary>
        private void TaskListButtonClicked(object? sender, EventArgs e)
        {
            taskPane.Clear();

            foreach (Process process in Process.GetProcesses())
            {
                if ((process.MainWindowHandle != nint.Zero)
                     && (!string.IsNullOrWhiteSpace(process.MainWindowTitle))
                            && Modules.Windows.IsWindowShowableOnOurTaskbar(process.MainWindowHandle)
                        )
                {
                    IntPtr hWnd = process.MainWindowHandle;

                    string windowTitle = process.MainWindowTitle;
                    if (!string.IsNullOrWhiteSpace(windowTitle))
                    {
#pragma warning disable IDE0059 // unnecessary assignment
                        Image icon = new Bitmap(1, 1);                      // workaround! Without this, we get the same icon as the last one!
#pragma warning restore IDE0059 // unnecessary assignment

                        icon = Icons.EnsureGetProcessIcon(process);
                        taskPane.Add(icon, windowTitle, hWnd, process.Id);
                    }
                }
            }

            taskPane.StartPosition = FormStartPosition.CenterScreen;
            taskPane.ShowDialog(this);
        }

        /// <summary>
        /// The "start" button was clicked. Show the program launcher!
        /// </summary>
        private void StartButtonClicked(object? sender, System.EventArgs e)
        {
            _programsLauncher.ShowDialog(this);
        }

        /// <summary>
        /// A custom button on the taskbar was clicked
        /// </summary>
        private void TaskbarCustomButton_Click(object? sender, EventArgs e)
        {
            string command = (string)((Button)sender!).Tag!;

            if (command.StartsWith(IShellAppModule.CommandSignifierPrefix))
            {
                IShellAppModule? app = ShellEnvironment.ShellApps.GetInstanceOf(command);
                app?.Execute(command, ShellEnvironment.WorkArea);
            }
            else
            {
                Shell32.ExecuteOrLaunchTarget(command);
            }
        }


        /// <summary>
        /// Initialise
        /// </summary>
        public Taskbar()
        {
            TaskbarButtonSizes = Icons.ToPixels(ShellEnvironment.ConfiguredSizeOfIcons.ToNextLargerSize());
            additionalButtons = new();

            _settings = ConfigurationProvider<TaskbarSettings>.Get(true);
            ConfigurationProvider<TaskbarSettings>.ConfigurationUpdated += ConfigurationProvider_ConfigurationUpdated;
            if (_settings.ShowAdditionalButtons)
            {
                _additionalButtonSettings = ConfigurationProvider<TaskbarAdditionalButtonsSettings>.Get(true);
            }
            else
            {
                _additionalButtonSettings = null;
            }

            InitializeComponent();
            ApplyTaskbarSettings();
        }

        private readonly TaskListPane taskPane = new();
        private readonly CanvasProgramLauncher _programsLauncher = new();
        private TaskbarSettings _settings;
        private TaskbarAdditionalButtonsSettings? _additionalButtonSettings;

        private Button? startButton;
        private Button? taskListButton;
        private Label? clockLabel;
        private readonly List<Button> additionalButtons;
        private System.Windows.Forms.Timer? clock;

        /// <summary>
        /// Sizes of buttons ON the taskbar. These will be one-size higher than the global size configured.
        /// </summary>
        private readonly int TaskbarButtonSizes;

        /// <summary>
        /// Calcuate the height of the taskbar for a given icon height
        /// </summary>
        public static int CalcHeight(IconSizesEnum iconSize) => Icons.ToPixels(iconSize.ToNextLargerSize()) + 6;
    }
}
