using System;
using System.Linq;
using System.Windows.Markup;

namespace CV19.Infrastructure.Common
{
    internal class StringToIntArray : MarkupExtension
    {

        public override object ProvideValue(IServiceProvider sp) =>
            Str.Split(new [] {Separator}, StringSplitOptions.RemoveEmptyEntries)
                .DefaultIfEmpty()
                .Select(int.Parse)
                .ToArray();

        [ConstructorArgument("Str")]
        public string Str { get; set; }

        public char Separator { get; set; } = ';';

        public StringToIntArray() { }

        public StringToIntArray(string str) => this.Str = str;
        
    }
}