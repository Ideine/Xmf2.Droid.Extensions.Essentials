using Android.App;
using Android.Content;
using Android.Net;

namespace Xmf2.Droid.Extensions.Essentials.Share
{
    public class ShareExtensions
    {
        public bool CanMakePhoneCall
        {
            get
            {
                const string INTENT_CHECK = "00000000000";
                Uri telUri = Uri.Parse($"tel:{INTENT_CHECK}");
                Intent intent = new Intent(Intent.ActionDial, telUri);
                var resolve = intent.ResolveActivity(Application.Context.PackageManager!);
                return resolve != null;
            }
        }

        public bool CanSendEmail
        {
            get
            {
                Intent intent = new Intent(Intent.ActionSendto);
                intent.SetData(Uri.Parse("mailto:"));
                intent.PutExtra(Intent.ExtraText, "This is a test email.");
                intent.PutExtra(Intent.ExtraSubject, "Email test");
                intent.PutExtra(Intent.ExtraEmail, "xmf2extensions@yopmail.com");
                var resolve = intent.ResolveActivity(Application.Context.PackageManager!);
                return resolve != null;
            }
        }

        public bool CanSendSms
        {
            get
            {
                Intent intent = new Intent(Intent.ActionView);
                string recipientUri = Uri.Encode("0000000000");
                Uri uri = Uri.Parse($"smsto:{recipientUri}");
                intent.SetData(uri);
                var resolve = intent.ResolveActivity(Application.Context.PackageManager!);
                return resolve != null;
            }
        }
    }
}