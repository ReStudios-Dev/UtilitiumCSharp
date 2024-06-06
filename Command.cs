using System;
using System.Collections.Generic;
using System.Linq;

namespace org.ReStudios.utitlitium
{
    public abstract class Command
    {
        private readonly Dictionary<string, Command> subCommands;
        private bool isSub;
        private string[] currentArgs;
        protected Command parent;
        private string alias;

        private int minArguments = 0;

        public Command()
        {
            subCommands = new Dictionary<string, Command>();
        }

        public Command(string alias)
        {
            subCommands = new Dictionary<string, Command>();
            this.alias = alias;
        }

        public int MinArguments { get => minArguments; }

        public Command SetMinArguments(int minArguments)
        {
            this.minArguments = minArguments;
            return this;
        }

        public Command AddSubCommand(Command command)
        {
            if (string.IsNullOrEmpty(command.alias) || command.alias.Trim().Equals(" "))
            {
                throw new ArgumentException("Adding root command to root command");
            }
            subCommands.Add(command.alias, command);
            command.isSub = true;
            command.parent = this;
            return this;
        }

        public Command GetRoot()
        {
            return isSub ? parent.GetRoot() : this;
        }

        public string[] GetRootArgs()
        {
            return isSub ? parent.GetRootArgs() : currentArgs;
        }

        public string[] GetParentArgs()
        {
            return !isSub ? currentArgs : parent.currentArgs;
        }

        public abstract bool ExecuteCommand(object sender, string[] args);

        public bool OnCommand(string[] args)
        {
            return OnCommand(null, args);
        }

        public bool OnCommand(object sender, string[] args)
        {
            currentArgs = args;
            foreach (string arg in args)
            {
                if (subCommands.ContainsKey(arg))
                {
                    return subCommands[arg].OnCommand(sender, Substring(args, 1, args.Length));
                }
            }
            if (MinArguments > args.Length)
            {
                Console.WriteLine(new ArgumentException($"Not enough arguments: {args.Length}. Minimum is {MinArguments}").StackTrace);
                return false;
            }
            return ExecuteCommand(sender, args);
        }

        public static T[] Substring<T>(T[] x, int beginIndex, int endIndex)
        {
            return x.Skip(beginIndex).Take(endIndex - beginIndex).ToArray();
        }
    }
}
