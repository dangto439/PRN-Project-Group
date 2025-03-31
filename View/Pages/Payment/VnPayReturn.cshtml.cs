using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace View.Pages.Payment
{
    public class VnPayReturnModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            //var vnp_HashSecret = _config.Vnp_HashSecret;
            var response = Request.Query;
            var vnp_ResponseCode = response["vnp_ResponseCode"];

            if (vnp_ResponseCode == "00")
            {
                Message = "Thanh toán thành công!";
            }
            else
            {
                Message = "Thanh toán thất bại!";
            }
        }
    }
}
