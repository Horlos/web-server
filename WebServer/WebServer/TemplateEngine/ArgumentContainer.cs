namespace WebServer.TemplateEngine
{
    using System;

    /// <summary>
    /// A container class grouping mapping name, argument type and the argument object
    /// </summary>
    public class ArgumentContainer
    {
        /// <summary>
        /// Contains the name mapped to the argument
        /// </summary>
        private readonly string _argumentName;

        /// <summary>
        /// Contains the type of the argument, this must be valid if _argumentObject is null
        /// </summary>
        private Type _argumentType;

        /// <summary>
        /// Holds the actual object
        /// </summary>
        private object _argumentObject;
       
        /// <summary>
        /// Constructor to initiate an ArgumentContainer, will set the ArgumentType to the value of the argumentObject's type
        /// </summary>
        /// <param name="argumentName">Cannot be null</param>
        /// <param name="argumentObject">Cannot be null</param>
        /// <exception cref="ArgumentNullException">If argumentName or argumentObject is null</exception>
        public ArgumentContainer(string argumentName, object argumentObject)
        {
            if (string.IsNullOrEmpty(argumentName))
                throw new ArgumentNullException("argumentName");

            if (_argumentObject == null)
                throw new ArgumentNullException("argumentObject", "Trying to add Null argument to key '" + argumentName + "'");

            _argumentName = argumentName;
            _argumentType = argumentObject.GetType();
            _argumentObject = argumentObject;
        }

        /// <summary>
        /// Alternative constructor allowing argumentObject parameter to be null
        /// </summary>
        /// <param name="argumentName">Cannot be null</param>
        /// <param name="argumentObject"></param>
        /// <param name="argumentType">Cannot be null</param>
        /// <exception cref="NullReferenceException">If argumentName or argumentType is null</exception>
        /// <exception cref="ArgumentException">If argumentObject != null and argumentType != typeof(argumentObject)</exception>
        public ArgumentContainer(string argumentName, object argumentObject, Type argumentType)
        {
            if (string.IsNullOrEmpty(argumentName))
                throw new ArgumentException("Parameter argumentName cannot be null or empty.");

            if (argumentType == null)
                throw new ArgumentNullException("argumentType", "Trying to add Null argument to key '" + argumentName + "'");

            if (argumentObject != null)
                if (!argumentType.IsAssignableFrom(argumentObject.GetType()))
                    throw new ArgumentException("Argument with key '" + argumentName + "' must be assignable to argumentType '" + argumentType + "'", "argumentObject");

            _argumentName = argumentName;
            _argumentObject = argumentObject;
            _argumentType = argumentType;
        }

        /// <summary>
        /// Attribute for retrieving the name. The name cannot be set however because an argument is defined by its name
        /// changing the name would be changing the arguments meaning, thus an argument needing a name change should rather
        /// be recreated 
        /// </summary>
        public string Name
        {
            get { return _argumentName; }
        }

        /// <summary>
        /// Returns the type of the argument object. The property cannot be set since the type depends on and must correspond to
        /// the type of the object 
        /// </summary>
        public Type Type
        {
            get { return _argumentType; }
        }

        /// <summary>
        /// Returns or changes the argument object. If the object is to be changed to null the type must be passed aswell,
        /// in that case <see cref="SetObject(object,System.Type)" />
        /// </summary>
        /// <exception cref="ArgumentNullException">If set value is null</exception>
        public object Object
        {
            get
            {
                return _argumentObject;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _argumentObject = value;
                _argumentType = _argumentObject.GetType();
            }
        }

        /// <summary>
        /// Sets the object and type of the argument, equal to ArgumentContainer.Object = ...
        /// </summary>
        /// <param name="argumentObject">Cannot be null</param>
        /// <exception cref="ArgumentNullException">If argumentObject is null</exception>
        public void SetObject(object argumentObject)
        {
            if (argumentObject == null)
                throw new ArgumentNullException("argumentObject", "Trying to add Null argument to key '" + _argumentName + "'");

            _argumentObject = argumentObject;
            _argumentType = _argumentObject.GetType();
        }

        /// <summary>
        /// Sets the argument object and type. Type of the object and argumentType must correspond.
        /// </summary>
        /// <param name="argumentObject"></param>
        /// <param name="argumentType">Cannot be null</param>
        /// <exception cref="ArgumentNullException">If argumentType is null</exception>
        /// <exception cref="ArgumentException">If typeof(argumentObject) differs from argumentType and object != null</exception>
        public void SetObject(object argumentObject, Type argumentType)
        {
            if (argumentType == null)
                throw new NullReferenceException("Parameter argumentType cannot be null for argumentObject with key '" + _argumentName + "'.");

            if (argumentObject != null)
                if (!argumentType.IsAssignableFrom(argumentObject.GetType()))
                    throw new ArgumentException("Argument with key '" + _argumentName + "' must be assignable to argumentType '" + argumentType + "'", "argumentObject");

            _argumentObject = argumentObject;
            _argumentType = argumentType;
        }
    }
}
