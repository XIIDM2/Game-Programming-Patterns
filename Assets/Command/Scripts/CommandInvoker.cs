using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Command
{
    public class CommandInvoker
    {
        private static Stack<ICommand> _undoStack = new Stack<ICommand>();
        private static Stack<ICommand> _redoStack = new Stack<ICommand>();

        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();

            _undoStack.Push(command);

            _redoStack.Clear();
        }

        public static void UndoCommand()
        {
            if (_undoStack.TryPop(out ICommand command))
            {
                _redoStack.Push(command);
                command.Undo();
            }
        }

        public static void RedoCommand()
        {
            if (_redoStack.TryPop(out ICommand command))
            {
                _undoStack.Push(command);
                command.Execute();
            }
        }
    }
}