using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompuSight.Metro.Samples.TestServer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string m_Text = @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Respondent extrema primis, media utrisque, omnia omnibus. Quantum Aristoxeni ingenium consumptum videmus in musicis? Mihi vero, inquit, placet agi subtilius et, ut ipse dixisti, pressius. Tubulo putas dicere? Duo Reges: constructio interrete. Est enim tanti philosophi tamque nobilis audacter sua decreta defendere.

Illud quaero, quid ei, qui in voluptate summum bonum ponat, consentaneum sit dicere. Sin kakan malitiam dixisses, ad aliud nos unum certum vitium consuetudo Latina traduceret.

Mihi quidem Antiochum, quem audis, satis belle videris attendere. Audeo dicere, inquit. Tum Triarius: Posthac quidem, inquit, audacius. Que Manilium, ab iisque M. Sed tu istuc dixti bene Latine, parum plane. Cuius ad naturam apta ratio vera illa et summa lex a philosophis dicitur. At ego quem huic anteponam non audeo dicere;

Ut aliquid scire se gaudeant? Quae fere omnia appellantur uno ingenii nomine, easque virtutes qui habent, ingeniosi vocantur. Illa sunt similia: hebes acies est cuipiam oculorum, corpore alius senescit; Dempta enim aeternitate nihilo beatior Iuppiter quam Epicurus; Primum cur ista res digna odio est, nisi quod est turpis? Aut haec tibi, Torquate, sunt vituperanda aut patrocinium voluptatis repudiandum. Ait enim se, si uratur, Quam hoc suave! dicturum. Nam memini etiam quae nolo, oblivisci non possum quae volo.

Sed fac ista esse non inportuna; Bona autem corporis huic sunt, quod posterius posui, similiora. Ita prorsus, inquam; Non est enim vitium in oratione solum, sed etiam in moribus.
";

        protected void Page_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < 8; i++)
            {
                m_Text += m_Text;
            }

            var bytes = Encoding.ASCII.GetBytes(m_Text);

            int written = 0;

            Debug.WriteLine("\t{0:o}\tSERVER: Starting Write of {1} bytes", DateTime.Now, bytes.Length);

            while (written != bytes.Length)
            {

                var bytesToWrite = bytes.Length - written > 1000 ? 1000 : bytes.Length - written;
                Response.Buffer = false;
                Response.BufferOutput = false;
                Response.OutputStream.Write(bytes, written, bytesToWrite);
                Response.OutputStream.Flush();
                written += bytesToWrite;

                Debug.WriteLine(string.Format("\t{0:o}\tSERVER: Written {1} bytes", DateTime.Now, written));

                Thread.Sleep(500);
            }

            Debug.WriteLine(string.Format("\t{0:o}\tSERVER: End Write of {1} bytes", DateTime.Now, bytes.Length));

        }
    }
}