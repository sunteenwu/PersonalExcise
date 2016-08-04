// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {

                document.getElementById("Mybutton").onclick = function (evt) {
                    var returnMessage = "";
                    var result = document.getElementById("result");
                    try {
                        var requestUri = new Windows.Foundation.Uri("https://localhost/");
                        var certQuery = new Windows.Security.Cryptography.Certificates.CertificateQuery();
                        certQuery.friendlyName = "WCFClientCert";

                        Windows.Security.Cryptography.Certificates.CertificateStores.findAllAsync(certQuery).done(function (certificates) {
                            if (certificates.length == 1) {
                            var aBPF = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
                            aBPF.clientCertificate = certificates[0];
                            var httpClient = new Windows.Web.Http.HttpClient(aBPF);
                            httpClient.getAsync(requestUri).then(
                                 function (response) {
                                     if (response) {
                                         if (response.statusCode == Windows.Web.Http.HttpStatusCode.ok) {
                                             returnMessage += "successful";
                                         }
                                         else {
                                             returnMessage += "failed with ";
                                             returnMessage += response.statusCode;
                                         }

                                         result.value = returnMessage;
                                     }
                                 },
                                 function (err) {
                                     var string = "test";
                                 });
                            }
                        }, function (err) {
                            err
                        });
                    }
                    catch (ex) {
                        returnMessage += "failed with ";
                        returnMessage += ex.Message;
                    }
                }
                // TODO: This application has been newly launched. Initialize your application here.
            } else {
                // TODO: This application was suspended and then terminated.
                // To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
            }
            args.setPromise(WinJS.UI.processAll());
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state that needs to persist across suspensions here.
        // You might use the WinJS.Application.sessionState object, which is automatically saved and restored across suspension.
        // If you need to complete an asynchronous operation before your application is suspended, call args.setPromise().
    };

    app.start();
})();


