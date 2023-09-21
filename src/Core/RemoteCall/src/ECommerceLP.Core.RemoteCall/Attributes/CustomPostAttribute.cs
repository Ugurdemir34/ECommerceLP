using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.RemoteCall.Attributes
{
    public class CustomPostAttribute:Refit.PostAttribute
    {
        public CustomPostAttribute(string path):base(path) { }
        public override HttpMethod Method => HttpMethod.Post;
    }
}
