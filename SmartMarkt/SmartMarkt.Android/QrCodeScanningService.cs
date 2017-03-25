using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SmartMarkt;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(SmartMarkt.Android.QrCodeScanningService))]

namespace SmartMarkt.Android
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions()
            {
                //UseFrontCameraIfAvailable = true,
                //Check diferents formats in http://barcode.tec-it.com/en
                // PossibleFormats = new List<ZXing.BarcodeFormat> {  ZXing.BarcodeFormat.CODE_128 }
            };
            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Acerca la cámara al elemento",
                BottomText = "Toca la pantalla para enfocar"
            };

            var scanResults = await scanner.Scan(optionsCustom);
            return scanResults.Text;
        }
    }
}