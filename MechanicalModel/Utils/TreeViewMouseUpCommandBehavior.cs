using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MechanicalModel.Utils
{
    public static class TreeViewMouseUpCommandBehavior
    {
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject obj, ICommand command)
        {
            obj.SetValue(CommandProperty, command);
        }

        public static object GetCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject obj, object commandParameter)
        {
            obj.SetValue(CommandParameterProperty, commandParameter);
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(TreeViewMouseUpCommandBehavior),
            new UIPropertyMetadata(OnCommandChanged));

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
            "CommandParameter",
            typeof(object),
            typeof(TreeViewMouseUpCommandBehavior),
            new UIPropertyMetadata(null));

        private static void OnCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TreeView treeView = obj as TreeView;
            if (treeView == null)
            {
                return;
            }

            treeView.MouseUp -= new MouseButtonEventHandler(TreeViewMouseUpEventHandler);
            treeView.MouseUp += new MouseButtonEventHandler(TreeViewMouseUpEventHandler);
        }

        private static void TreeViewMouseUpEventHandler(object sender, MouseButtonEventArgs e)
        {
            DependencyObject obj = sender as DependencyObject;
            if (obj == null)
            {
                return;
            }

            if ((e.ChangedButton != MouseButton.Left) || (e.ButtonState != MouseButtonState.Released))
            {
                return;
            }

            ICommand command = obj.GetValue(CommandProperty) as ICommand;
            if (command == null)
            {
                return;
            }

            command.Execute(obj.GetValue(CommandParameterProperty));
        }
    }
}
