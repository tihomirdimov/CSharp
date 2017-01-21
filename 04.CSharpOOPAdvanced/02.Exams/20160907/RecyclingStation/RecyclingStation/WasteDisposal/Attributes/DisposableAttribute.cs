namespace RecyclingStation.WasteDisposal.Attributes
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>

    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
        public static explicit operator DisposableAttribute(List<object> v)
        {
            throw new NotImplementedException();
        }
    }
}
