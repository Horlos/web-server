namespace WebServer.ViewEngine.Exceptions
{
    using System;

    /// <summary>
    /// Represent general errors during compilation of templates
    /// </summary>
    public class ViewCompilerException : Exception
    {
        /// <summary>
        /// Creates an exception with the supplied messages
        /// </summary>
        public ViewCompilerException(string message)
            : base(message)
        {
        }
    }
}