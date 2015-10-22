namespace WebServer.Parameters
{
    using System.Collections.Generic;
    using Infrastructure;

    /// <summary>
    /// 
    /// </summary>
    public interface IParameter: IAggregate<string>
    {
        /// <summary>
        /// Gets *last* value.
        /// </summary>
        /// <remarks>
        /// Parameters can have multiple values. This property will always get the last value in the list.
        /// </remarks>
        /// <value>String if any value exist; otherwise <c>null</c>.</value>
        string Value { get; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a list of all values.
        /// </summary>
        List<string> Values { get; }
    }
}
