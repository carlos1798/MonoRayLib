using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace monoos.src.Render.BaseRenders
{
    public abstract class ConcreteRender<T>
    {
        public T property;
        public BoardRectangle location;

        protected ConcreteRender(T prop, BoardRectangle br)
        {
            this.property = prop;
            this.location = br;
        }

        public abstract void RenderLocation();

        public string FormatName(string input)
        {
            var regex = new Regex(@"\b[a-zA-Z]+\b");
            input = input.Replace(" ", "\n");
            var result = regex.Replace(input, m =>
            {
                var word = m.Value;
                if (word.Length > 8)
                {
                    return word.Insert(word.Length - (word.Length - 7), "-\n");
                }
                else
                {
                    return word;
                }
            });
            return result;
        }
    }
}