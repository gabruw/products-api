using System.Collections.Generic;
using System.Linq;

namespace Products.Utils
{
    public class Response<TEntity>
    {
        public TEntity Data { get; set; }

        private List<string> _errors;
        public List<string> Errors
        {
            get
            {
                if (_errors == null)
                {
                    _errors = new List<string>();
                }

                return _errors;
            }
            set
            {
                _errors = value;
            }
        }

        public Response()
        {

        }

        public bool hasErrors()
        {
            return Errors.Count() > 0;
        }
    }
}
