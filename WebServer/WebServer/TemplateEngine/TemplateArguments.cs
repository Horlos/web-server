namespace WebServer.TemplateEngine
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Arguments being used in a template.
    /// </summary>
    /// <seealso cref="TemplateManager"/>
    /// <seealso cref="ITinyTemplate"/>
    public class TemplateArguments
    {
        /// <summary>
        /// Holds the arguments connected to their names for quick access.
        /// (since the ArgumentContainer also holds the name for the argument the mapping with strings is somewhat redundant
        /// but since the data do 'belong' to the ArgumentContainer this solution was chosen to speed up access)
        /// </summary>
        private Dictionary<string, ArgumentContainer> _arguments;

        /// <summary>
        /// Initializes the class without any set arguments.
        /// </summary>
        public TemplateArguments()
        {
            _arguments = new Dictionary<string, ArgumentContainer>();
        }

        /// <summary>
        /// Initializes the class with all the arguments of the parameter class.
        /// </summary>
        /// <param name="arguments">Cannot be null</param>
        /// <exception cref="ArgumentNullException">If arguments is null</exception>
        public TemplateArguments(TemplateArguments arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException("arguments");

            _arguments = new Dictionary<string, ArgumentContainer>(arguments._arguments);
        }

        /// <summary>
        /// Initializes the class with the objects in the parameterlist.
        /// Note that each object that is null must be followed by a type.
        /// </summary>
        /// <param name="arguments">Should contain ordered pairs/truples of string, object and type where type is optional if the object isnґt null</param>
        /// <example>new TemplateArguments("Dir", "\", "Users", null, typeof(User));</example>
        /// <exception cref="ArgumentException">If optional type differs from type of object (if object != null) or argument name is duplicate</exception>
        /// <exception cref="ArgumentException">If the order of objects is incorrect</exception>
        /// <exception cref="ArgumentNullException">If any argument name or type is null</exception>
        public TemplateArguments(params object[] arguments)
        {
            _arguments = new Dictionary<string, ArgumentContainer>();

            int index = 0;
            while (index < arguments.Length)
            {
                if (arguments[index] == null)
                    throw new ArgumentNullException("arguments");
                if (arguments[index].GetType() != typeof(string))
                    throw new ArgumentException("Identifier of argument must be a string.");
                if (arguments.Length - index < 2)
                    throw new ArgumentException("Incorrect number of parameters passed, must be in two's and three's");

                if (index + 2 < arguments.Length && ((Type)arguments[index + 2] == typeof(Type)))
                    Add((string)arguments[index++], arguments[index++], (Type)arguments[index++]);
                else
                    Add((string)arguments[index++], arguments[index++]);
            }
        }

        /// <summary>
        /// Clears added arguments
        /// </summary>
        ~TemplateArguments()
        {
            _arguments.Clear();
            _arguments = null;
        }

        /// <summary>
        /// Function to make it possible to index out known arguments
        /// </summary>
        /// <param name="name">The name of an added argument</param>
        /// <returns>Null if no ArgumentContainer by name was found</returns>
        public ArgumentContainer this[string name]
        {
            get { return _arguments[name]; }
        }

        /// <summary>
        /// A function that merges two argument holders updating and adding values
        /// </summary>
        /// <param name="arguments"></param>
        /// <exception cref="ArgumentNullException">If arguments is null</exception>
        public void Update(TemplateArguments arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException("arguments");

            foreach (ArgumentContainer argument in arguments.GetArguments())
            {
                if (_arguments.ContainsKey(argument.Name))
                    _arguments[argument.Name] = argument;
                else
                    _arguments.Add(argument.Name, argument);
            }
        }

        /// <summary>
        /// Adds an argument.
        /// (Will throw ArgumentException on duplicates since adding an argument twice points to incorrect code, for ways around
        /// this <see cref="Update(string,object)" />
        /// </summary>
        /// <param name="argumentName">Cannot be null</param>
        /// <param name="argumentObject">Cannot be null</param>
        /// <exception cref="NullReferenceException">If argumentName or argumentObject is null</exception>
        /// <exception cref="ArgumentException">If an argument named argumentName already exists</exception>
        public void Add(string argumentName, object argumentObject)
        {
            if (argumentObject == null)
                throw new ArgumentNullException("argumentObject", "Trying to add Null argument to key '" + argumentName + "'");

            Add(argumentName, argumentObject, argumentObject.GetType());
        }

        /// <summary>
        /// Adds an argument. Allows for argumentObject to be null
        /// (Will throw ArgumentException <see cref="Add(string,object)" />
        /// </summary>
        /// <param name="argumentName">Cannot be null</param>
        /// <param name="argumentObject"></param>
        /// <param name="argumentType">Cannot be null</param>
        /// <exception cref="NullReferenceException">If argumentName or argumentType is null</exception>
        /// <exception cref="ArgumentException">If an argument named argumentName already exists or argumentObject != null and typeof(argumentObject) differs from argumentType</exception>
        public void Add(string argumentName, object argumentObject, Type argumentType)
        {
            if (_arguments.ContainsKey(argumentName))
                throw new ArgumentException("Argument named '" + argumentName + "' already exists");

            _arguments.Add(argumentName, new ArgumentContainer(argumentName, argumentObject, argumentType));
        }

        /// <summary>
        /// Updates an already added argument
        /// </summary>
        /// <param name="argumentName">Cannot be null</param>
        /// <param name="argumentObject">Cannot be null</param>
        /// <exception cref="ArgumentException">If no argument named argumentName exists</exception>
        /// <exception cref="ArgumentNullException">If argumentName or argumentObject is null</exception>
        public void Update(string argumentName, object argumentObject)
        {
            if (argumentObject == null)
                throw new ArgumentNullException("argumentObject", "Trying to add Null argument to key '" + argumentName + "'");

            Update(argumentName, argumentObject, argumentObject.GetType());
        }

        /// <summary>
        /// Updates an already added argument, allows for argumentObject to be null
        /// </summary>
        /// <param name="argumentName">Cannot be null</param>
        /// <param name="argumentObject"></param>
        /// <param name="argumentType">Cannot be null</param>
        /// <exception cref="ArgumentNullException">If argumentName or argumentType is null</exception>
        /// <exception cref="ArgumentException">If an argument named argumentName doesnґt exists or argumentObject != null and typeof(argumentObject) differs from argumentType</exception>
        public void Update(string argumentName, object argumentObject, Type argumentType)
        {
            if (string.IsNullOrEmpty(argumentName))
                throw new ArgumentNullException("argumentName");

            if (_arguments.ContainsKey(argumentName) == false)
                throw new ArgumentException("No argument named '" + argumentName + "' exists.");

            _arguments[argumentName].SetObject(argumentObject, argumentType);
        }

        /// <summary>
        /// Clears all added arguments
        /// </summary>
        public void Clear()
        {
            _arguments.Clear();
        }

        /// <summary>
        /// Retrieves the arguments
        /// (Does so now by copying the values to a new array, could be optimized?)
        /// </summary>
        /// <returns>An array containing arguments with name, object and type</returns>
        public ArgumentContainer[] GetArguments()
        {
            List<ArgumentContainer> arguments = new List<ArgumentContainer>();
            foreach (KeyValuePair<string, ArgumentContainer> pair in _arguments)
                arguments.Add(pair.Value);

            return arguments.ToArray();
        }

        /// <summary>
        /// Returns a individual hashcode built upon the specified types the class is holding
        /// </summary>
        /// <remarks>The hashcode is made by joining the typenames of all held arguments and making a string hashcode from them</remarks>
        /// <returns></returns>
        public override int GetHashCode()
        {
            string hash = string.Empty;
            foreach (KeyValuePair<string, ArgumentContainer> pair in _arguments)
                hash += GetFullTypeName(pair.Value.Type);

            return hash.GetHashCode();
        }

        /// <summary>
        /// Checks whether a specific argument is specified or not.
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <returns>true if argument is specified; otherwise false.</returns>
        public bool Contains(string name)
        {
            return _arguments.ContainsKey(name);
        }

        /// <summary>
        /// Retrieves a concated typename ie DictinaryInt32String
        /// </summary>
        /// <param name="type">The type to retrieve the name for</param>
        private static string GetFullTypeName(Type type)
        {
            string name = type.Namespace + "." + type.Name.Replace("`" + type.GetGenericArguments().Length, string.Empty);
            foreach (Type genericArgument in type.GetGenericArguments())
                name += GetFullTypeName(genericArgument);

            return name;
        }
    }
}
