using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRtfDemo
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
           // Html = @"<body><p><strong>Hello</strong><br />wow whufwehfuw uwfhuwhfu weu hwfwue weoufweh weuh weuh wefw <br /></p><p><strong>Hello</strong><br />wow whufwehfuw uwfhuwhfu weu hwfwue weoufweh weuh weuh wefw <br /></p><p><strong>Hello</strong><br />wow whufwehfuw uwfhuwhfu weu hwfwue weoufweh weuh weuh wefw <br /></p></body>";
            //Html = @"<body><p>Hello&nbsp;test,</p><p>Welcome to iTV</p><p>Thanks</p></body>";
            Html = @"<body><p>Hello test,</p><p>Welcome to iTV</p><p>Thanks</p></body>";
        }

        public string Html
        {
            get;
            set;
        }
    }
}
