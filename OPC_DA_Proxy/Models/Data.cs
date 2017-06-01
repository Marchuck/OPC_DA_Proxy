using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace OPC_DA_Proxy.Models
{
    public class Data
    {
        public static string[] availablePicturesImpl2()
        {
            var server = HttpContext.Current.Server;
            var picturesPath = server.MapPath("~/pictures");

            DirectoryInfo d = new DirectoryInfo(picturesPath);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.svg"); //Getting Text files
            string[] files = new string[Files.Length];
            for (int j = 0; j < Files.Length; j++)
            {
                files[j] = Files[j].Name.Replace(".svg","");
            }
            return files;
        }

       public static string forId(string id)
        {

            try
            {
                var server = HttpContext.Current.Server;
                var picturesPath = server.MapPath("~/pictures");
               // var filePath = Path.Combine(picturesPath,id);
                var filePath = Path.Combine(picturesPath, $"{id}.svg");
                var svg = File.ReadAllText(filePath);
                return svg;
            }
            catch (Exception fileNotFoundException)
            {
            }
            return $"{id} could not be found.";

        }
        public static string forIdLegacy(string id)
        {

            if (id.Equals("zbiorniki"))
            {
                var server = HttpContext.Current.Server;
                var picturesPath = server.MapPath("~/pictures");
                var filePath = Path.Combine(picturesPath, $"{id}.svg");
                var svg = File.ReadAllText(filePath);
            }
            return "";
        }


        public static  string Zbiorniki() {return "<svg xmlns:gef=\"urn:schemas-gefanuc:gefschemas.xsd\"\n" +
    "     New_Height=\"346\" New_Width=\"478\" background-fill=\"#ffffff\" height=\"100\"\n" +
    "     version=\"1.2\" width=\"133\" xmlns=\"http://www.w3.org/2000/svg\" gef:DisableAutoScale=\"false\"\n" +
    "     gef:EnhancedCoordinates=\"true\" gef:GlobalTimeSync=\"true\" gef:RecalculateViewport=\"true\"\n" +
    "     gef:alwaysOnTop=\"true\"\n" +
    "     gef:blend=\"50\" gef:cacheEnabled=\"false\" gef:displayLayer=\"-1\"\n" +
    "     gef:fadeColor=\"#ffffff\" gef:fadeType=\"0\" gef:gradientAngle=\"0.000000\"\n" +
    "     gef:gradientEnabled=\"false\" gef:gridEnabled=\"false\" gef:gridInterval=\"15\"\n" +
    "     gef:languageDesired=\"1045\"\n" +
    "     gef:resizable=\"false\" gef:runtimeVisible=\"true\" gef:snapToGrid=\"false\"\n" +
    "     gef:systemMenu=\"true\" gef:titlebar=\"true\" gef:translateOnOpen=\"true\">\n" +
    "    <title>ZBIORNIKI.GRF</title>\n" +
    "    <gef:author>Lukasz</gef:author>\n" +
    "    <gef:version gef:major=\"1\" gef:minor=\"1\" gef:revision=\"0\"/>\n" +
    "    <defs>\n" +
    "        <linearGradient id=\"FillStyleGradient_DataLink1\" spreadMethod=\"pad\" x1=\"0%\" x2=\"100%\">\n" +
    "            <stop offset=\"0%\" stop-color=\"#ffffff\"/>\n" +
    "            <stop offset=\"100%\" stop-color=\"#ffffff\"/>\n" +
    "        </linearGradient>\n" +
    "        <linearGradient id=\"FillStyleGradient_DataLink2\" spreadMethod=\"pad\" x1=\"0%\" x2=\"100%\">\n" +
    "            <stop offset=\"0%\" stop-color=\"#ffffff\"/>\n" +
    "            <stop offset=\"100%\" stop-color=\"#ffffff\"/>\n" +
    "        </linearGradient>\n" +
    "        <linearGradient id=\"FillStyleGradient_DataLink3\" spreadMethod=\"pad\" x1=\"0%\" x2=\"100%\">\n" +
    "            <stop offset=\"0%\" stop-color=\"#ffffff\"/>\n" +
    "            <stop offset=\"100%\" stop-color=\"#ffffff\"/>\n" +
    "        </linearGradient>\n" +
    "    </defs>\n" +
    "    <g fill-rule=\"evenodd\" stroke-linecap=\"round\" stroke-linejoin=\"round\">\n" +
    "        <rect background-fill=\"#ffffff\" fill=\"#c00000\" height=\"130\" id=\"Rect1\" stroke=\"#000000\"\n" +
    "              stroke-width=\"1\" transform=\"rotate(0.000000deg,361,147)\"\n" +
    "              width=\"98\" x=\"312\" y=\"82\"\n" +
    "              gef:enableHighlight=\"true\" gef:enableSelect=\"true\"\n" +
    "              gef:verticalScaleDirection=\"bottomToTop\">\n" +
    "            <tooltipOption>TooltipDescription</tooltipOption>\n" +
    "        </rect>\n" +
    "        <rect background-fill=\"#ffffff\" fill=\"#000000\" height=\"127\" id=\"Rect2\" stroke=\"#000000\"\n" +
    "              stroke-width=\"1\" transform=\"rotate(0.000000deg,221,147)\"\n" +
    "              width=\"96\" x=\"173\" y=\"83\"\n" +
    "              gef:enableHighlight=\"true\" gef:enableSelect=\"true\"\n" +
    "              gef:verticalFillDirection=\"topToBottom\" gef:verticalScaleDirection=\"bottomToTop\">\n" +
    "            <tooltipOption>TooltipDescription</tooltipOption>\n" +
    "        </rect>\n" +
    "        <rect background-fill=\"#ffffff\" fill=\"#00a000\" height=\"123\" id=\"Rect3\" stroke=\"#000000\"\n" +
    "              stroke-width=\"1\" transform=\"rotate(0.000000deg,94,145)\"\n" +
    "              width=\"88\" x=\"50\" y=\"83\"\n" +
    "              gef:enableHighlight=\"true\" gef:enableSelect=\"true\"\n" +
    "              gef:verticalScaleDirection=\"bottomToTop\">\n" +
    "            <tooltipOption>TooltipDescription</tooltipOption>\n" +
    "        </rect>\n" +
    "        <gef:dataLink background-fill=\"url(#FillStyleGradient_DataLink1)\" fill=\"#00008e\"\n" +
    "                      font-family=\"Arial\" font-size=\"16\" id=\"DataLink1\"\n" +
    "                      lengthAdjust=\"spacingAndGlyphs\" stroke=\"none\" stroke-width=\"0\"\n" +
    "                      textLength=\"22\" x=\"66\"\n" +
    "                      y=\"74\" gef:charsPerLine=\"3\" gef:transparent=\"true\"\n" +
    "                      gef:verticalScaleDirection=\"bottomToTop\">#,#\n" +
    "            <tooltipOption>TooltipDescription</tooltipOption>\n" +
    "        </gef:dataLink>\n" +
    "        <gef:dataLink background-fill=\"url(#FillStyleGradient_DataLink2)\" fill=\"#00008e\"\n" +
    "                      font-family=\"Arial\" font-size=\"16\" id=\"DataLink2\"\n" +
    "                      lengthAdjust=\"spacingAndGlyphs\" stroke=\"none\" stroke-width=\"0\"\n" +
    "                      textLength=\"49\" x=\"190\"\n" +
    "                      y=\"77\" gef:charsPerLine=\"6\" gef:transparent=\"true\"\n" +
    "                      gef:verticalScaleDirection=\"bottomToTop\">###,##\n" +
    "            <tooltipOption>TooltipDescription</tooltipOption>\n" +
    "        </gef:dataLink>\n" +
    "        <gef:dataLink background-fill=\"url(#FillStyleGradient_DataLink3)\" fill=\"#00008e\"\n" +
    "                      font-family=\"Arial\" font-size=\"16\" id=\"DataLink3\"\n" +
    "                      lengthAdjust=\"spacingAndGlyphs\" stroke=\"none\" stroke-width=\"0\"\n" +
    "                      text-anchor=\"end\" textLength=\"76\"\n" +
    "                      x=\"395\" y=\"75\" gef:charsPerLine=\"9\"\n" +
    "                      gef:transparent=\"true\" gef:verticalScaleDirection=\"bottomToTop\">####,####\n" +
    "            <tooltipOption>TooltipDescription</tooltipOption>\n" +
    "        </gef:dataLink>\n" +
    "    </g>\n" +
    "    <foreignObject>\n" +
    "        <gef:dataConnectors>\n" +
    "            <gef:dataConnector id=\"Fix32\" gef:connectorType=\"FIX\">\n" +
    "                <gef:progid>Intellution.OPCEDA</gef:progid>\n" +
    "                <gef:physicalNodeName>FIX</gef:physicalNodeName>\n" +
    "                <gef:dataItem id=\"FIX32.FIX.BLACKY.F_CV\" gef:type=\"float\">FIX.BLACKY.F_CV\n" +
    "                </gef:dataItem>\n" +
    "                <gef:dataItem id=\"FIX32.FIX.GREEN.F_CV\" gef:type=\"float\">FIX.GREEN.F_CV\n" +
    "                </gef:dataItem>\n" +
    "                <gef:dataItem id=\"FIX32.FIX.RED.F_CV\" gef:type=\"float\">FIX.RED.F_CV</gef:dataItem>\n" +
    "            </gef:dataConnector>\n" +
    "        </gef:dataConnectors>\n" +
    "        <gef:symbols/>\n" +
    "        <gef:auxiliaryObjects>\n" +
    "            <gef:graphicConnections/>\n" +
    "            <gef:animations>\n" +
    "                <gef:rangeAnimation id=\"Linear3\" gef:autoFetchInput=\"false\"\n" +
    "                                    gef:errorMode=\"errorTable\"\n" +
    "                                    gef:highInputValue=\"1000\" gef:lowInputValue=\"0\"\n" +
    "                                    gef:maxOutputValue=\"100\" gef:minOutputValue=\"0\"\n" +
    "                                    gef:verticalFillDirection=\"bottomToTop\"\n" +
    "                                    gef:verticalFillPercentage=\"100.000000\">\n" +
    "                    <gef:animatedProperty>verticalFillPercentage</gef:animatedProperty>\n" +
    "                    <gef:expression>\n" +
    "                        <math xmlns=\"http://www.w3.org/1998/Math/MathML\">\n" +
    "                            <semantics>\n" +
    "                                <apply>\n" +
    "                                    <plus/>\n" +
    "                                    <ci>FIX32.FIX.RED.F_CV</ci>\n" +
    "                                </apply>\n" +
    "                            </semantics>\n" +
    "                        </math>\n" +
    "                    </gef:expression>\n" +
    "                </gef:rangeAnimation>\n" +
    "                <gef:rangeAnimation id=\"Linear2\" gef:autoFetchInput=\"false\"\n" +
    "                                    gef:errorMode=\"errorTable\"\n" +
    "                                    gef:highInputValue=\"100\" gef:lowInputValue=\"1\"\n" +
    "                                    gef:maxOutputValue=\"100\" gef:minOutputValue=\"0\"\n" +
    "                                    gef:verticalFillDirection=\"topToBottom\"\n" +
    "                                    gef:verticalFillPercentage=\"100.000000\">\n" +
    "                    <gef:animatedProperty>verticalFillPercentage</gef:animatedProperty>\n" +
    "                    <gef:expression>\n" +
    "                        <math xmlns=\"http://www.w3.org/1998/Math/MathML\">\n" +
    "                            <semantics>\n" +
    "                                <apply>\n" +
    "                                    <plus/>\n" +
    "                                    <ci>FIX32.FIX.BLACKY.F_CV</ci>\n" +
    "                                </apply>\n" +
    "                            </semantics>\n" +
    "                        </math>\n" +
    "                    </gef:expression>\n" +
    "                </gef:rangeAnimation>\n" +
    "                <gef:rangeAnimation id=\"Linear1\" gef:autoFetchInput=\"false\"\n" +
    "                                    gef:errorMode=\"errorTable\"\n" +
    "                                    gef:highInputValue=\"1\" gef:lowInputValue=\"0\"\n" +
    "                                    gef:maxOutputValue=\"100\" gef:minOutputValue=\"0\"\n" +
    "                                    gef:verticalFillDirection=\"bottomToTop\"\n" +
    "                                    gef:verticalFillPercentage=\"100.000000\">\n" +
    "                    <gef:animatedProperty>verticalFillPercentage</gef:animatedProperty>\n" +
    "                    <gef:expression>\n" +
    "                        <math xmlns=\"http://www.w3.org/1998/Math/MathML\">\n" +
    "                            <semantics>\n" +
    "                                <apply>\n" +
    "                                    <plus/>\n" +
    "                                    <ci>FIX32.FIX.GREEN.F_CV</ci>\n" +
    "                                </apply>\n" +
    "                            </semantics>\n" +
    "                        </math>\n" +
    "                    </gef:expression>\n" +
    "                </gef:rangeAnimation>\n" +
    "                <gef:formatAnimation id=\"Format1\" gef:confirmation=\"false\"\n" +
    "                                     gef:dataEntryType=\"0\" gef:decimalDigits=\"1\"\n" +
    "                                     gef:errorMode=\"errorTable\" gef:formatType=\"numeric\"\n" +
    "                                     gef:integerDigits=\"1\" gef:justification=\"left\">\n" +
    "                    <gef:animatedProperty>caption</gef:animatedProperty>\n" +
    "                    <gef:expression>\n" +
    "                        <math xmlns=\"http://www.w3.org/1998/Math/MathML\">\n" +
    "                            <semantics>\n" +
    "                                <apply>\n" +
    "                                    <plus/>\n" +
    "                                    <ci>FIX32.FIX.GREEN.F_CV</ci>\n" +
    "                                </apply>\n" +
    "                            </semantics>\n" +
    "                        </math>\n" +
    "                    </gef:expression>\n" +
    "                </gef:formatAnimation>\n" +
    "                <gef:formatAnimation id=\"Format2\" gef:confirmation=\"false\"\n" +
    "                                     gef:dataEntryType=\"0\" gef:decimalDigits=\"2\"\n" +
    "                                     gef:errorMode=\"errorTable\" gef:formatType=\"numeric\"\n" +
    "                                     gef:integerDigits=\"3\" gef:justification=\"left\">\n" +
    "                    <gef:animatedProperty>caption</gef:animatedProperty>\n" +
    "                    <gef:expression>\n" +
    "                        <math xmlns=\"http://www.w3.org/1998/Math/MathML\">\n" +
    "                            <semantics>\n" +
    "                                <apply>\n" +
    "                                    <plus/>\n" +
    "                                    <ci>FIX32.FIX.BLACKY.F_CV</ci>\n" +
    "                                </apply>\n" +
    "                            </semantics>\n" +
    "                        </math>\n" +
    "                    </gef:expression>\n" +
    "                </gef:formatAnimation>\n" +
    "                <gef:formatAnimation id=\"Format3\" gef:confirmation=\"false\"\n" +
    "                                     gef:dataEntryType=\"0\" gef:decimalDigits=\"4\"\n" +
    "                                     gef:errorMode=\"errorTable\" gef:formatType=\"numeric\"\n" +
    "                                     gef:integerDigits=\"4\" gef:justification=\"right\">\n" +
    "                    <gef:animatedProperty>caption</gef:animatedProperty>\n" +
    "                    <gef:expression>\n" +
    "                        <math xmlns=\"http://www.w3.org/1998/Math/MathML\">\n" +
    "                            <semantics>\n" +
    "                                <apply>\n" +
    "                                    <plus/>\n" +
    "                                    <ci>FIX32.FIX.RED.F_CV</ci>\n" +
    "                                </apply>\n" +
    "                            </semantics>\n" +
    "                        </math>\n" +
    "                    </gef:expression>\n" +
    "                </gef:formatAnimation>\n" +
    "            </gef:animations>\n" +
    "            <gef:commands/>\n" +
    "        </gef:auxiliaryObjects>\n" +
    "        <gef:bindings>\n" +
    "            <gef:binding>\n" +
    "                <gef:bindKey>Rect1</gef:bindKey>\n" +
    "                <gef:bindValue>Linear3</gef:bindValue>\n" +
    "            </gef:binding>\n" +
    "            <gef:binding>\n" +
    "                <gef:bindKey>Rect2</gef:bindKey>\n" +
    "                <gef:bindValue>Linear2</gef:bindValue>\n" +
    "            </gef:binding>\n" +
    "            <gef:binding>\n" +
    "                <gef:bindKey>Rect3</gef:bindKey>\n" +
    "                <gef:bindValue>Linear1</gef:bindValue>\n" +
    "            </gef:binding>\n" +
    "            <gef:binding>\n" +
    "                <gef:bindKey>DataLink1</gef:bindKey>\n" +
    "                <gef:bindValue>Format1</gef:bindValue>\n" +
    "            </gef:binding>\n" +
    "            <gef:binding>\n" +
    "                <gef:bindKey>DataLink2</gef:bindKey>\n" +
    "                <gef:bindValue>Format2</gef:bindValue>\n" +
    "            </gef:binding>\n" +
    "            <gef:binding>\n" +
    "                <gef:bindKey>DataLink3</gef:bindKey>\n" +
    "                <gef:bindValue>Format3</gef:bindValue>\n" +
    "            </gef:binding>\n" +
    "        </gef:bindings>\n" +
    "    </foreignObject>\n" +
    "    <gef:script id=\"Zbiorniki.cls\" type=\"text/vbscript\">\n" +
    "        <gef:scriptText>VERSION 1.0 CLASS</gef:scriptText>\n" +
    "        <gef:scriptText>BEGIN</gef:scriptText>\n" +
    "        <gef:scriptText>MultiUse = -1 'True</gef:scriptText>\n" +
    "        <gef:scriptText>END</gef:scriptText>\n" +
    "        <gef:scriptText>Attribute VB_Name = \"Zbiorniki\"</gef:scriptText>\n" +
    "        <gef:scriptText>Attribute VB_GlobalNameSpace = False</gef:scriptText>\n" +
    "        <gef:scriptText>Attribute VB_Creatable = False</gef:scriptText>\n" +
    "        <gef:scriptText>Attribute VB_PredeclaredId = True</gef:scriptText>\n" +
    "        <gef:scriptText>Attribute VB_Exposed = True</gef:scriptText>\n" +
    "        <gef:scriptText>Private Sub Rect1_Click()</gef:scriptText>\n" +
    "        <gef:scriptText>'Poniższe komentarze zostały dodane automatycznie.</gef:scriptText>\n" +
    "        <gef:scriptText>'Jakiekolwiek zmiany mogą zmniejszyć funkcjonalność</gef:scriptText>\n" +
    "        <gef:scriptText>'Ekspertów autoryzacji skryptów.</gef:scriptText>\n" +
    "        <gef:scriptText>'WizardName=WprowadzanieDanych</gef:scriptText>\n" +
    "        <gef:scriptText>On Error GoTo ErrorHandler</gef:scriptText>\n" +
    "        <gef:scriptText>If blnDataEntryFrmFlag &lt;&gt; True Then</gef:scriptText>\n" +
    "        <gef:scriptText>Dim dblLow, dblHigh As Double</gef:scriptText>\n" +
    "        <gef:scriptText>Dim blnFetch, blnContinous As Boolean</gef:scriptText>\n" +
    "        <gef:scriptText>GetFormSlider</gef:scriptText>\n" +
    "        <gef:scriptText>dblLow = 0</gef:scriptText>\n" +
    "        <gef:scriptText>dblHigh = 1000</gef:scriptText>\n" +
    "        <gef:scriptText>If (dblHigh &gt; 32767) Then</gef:scriptText>\n" +
    "        <gef:scriptText>MsgBox \" The high limit cannot be greater than 32,767 for this type of Data\n" +
    "            Entry, Please choose another.\"\n" +
    "        </gef:scriptText>\n" +
    "        <gef:scriptText>Exit Sub</gef:scriptText>\n" +
    "        <gef:scriptText>End If</gef:scriptText>\n" +
    "        <gef:scriptText>blnFetch = False</gef:scriptText>\n" +
    "        <gef:scriptText>blnContinous = False</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.SetWriteContinous blnContinous</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.Slider1.Min = CInt(dblLow)</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.Slider1.Max = CInt(dblHigh)</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.GetTheVars A:=1, B:=\"Fix32.FIX.RED.F_CV\"</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.lblLow.Caption = dblLow</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.lblHigh.Caption = dblHigh</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.Show</gef:scriptText>\n" +
    "        <gef:scriptText>End If</gef:scriptText>\n" +
    "        <gef:scriptText>Exit Sub</gef:scriptText>\n" +
    "        <gef:scriptText>ErrorHandler:</gef:scriptText>\n" +
    "        <gef:scriptText>HandleError</gef:scriptText>\n" +
    "        <gef:scriptText>End Sub</gef:scriptText>\n" +
    "        <gef:scriptText></gef:scriptText>\n" +
    "        <gef:scriptText>Private Sub Rect2_Click()</gef:scriptText>\n" +
    "        <gef:scriptText>'Poniższe komentarze zostały dodane automatycznie.</gef:scriptText>\n" +
    "        <gef:scriptText>'Jakiekolwiek zmiany mogą zmniejszyć funkcjonalność</gef:scriptText>\n" +
    "        <gef:scriptText>'Ekspertów autoryzacji skryptów.</gef:scriptText>\n" +
    "        <gef:scriptText>'WizardName=WprowadzanieDanych</gef:scriptText>\n" +
    "        <gef:scriptText>On Error GoTo ErrorHandler</gef:scriptText>\n" +
    "        <gef:scriptText>If blnDataEntryFrmFlag &lt;&gt; True Then</gef:scriptText>\n" +
    "        <gef:scriptText>Dim dblLow, dblHigh As Double</gef:scriptText>\n" +
    "        <gef:scriptText>Dim blnFetch, blnContinous As Boolean</gef:scriptText>\n" +
    "        <gef:scriptText>GetFormSlider</gef:scriptText>\n" +
    "        <gef:scriptText>dblLow = 1</gef:scriptText>\n" +
    "        <gef:scriptText>dblHigh = 100</gef:scriptText>\n" +
    "        <gef:scriptText>If (dblHigh &gt; 32767) Then</gef:scriptText>\n" +
    "        <gef:scriptText>MsgBox \" The high limit cannot be greater than 32,767 for this type of Data\n" +
    "            Entry, Please choose another.\"\n" +
    "        </gef:scriptText>\n" +
    "        <gef:scriptText>Exit Sub</gef:scriptText>\n" +
    "        <gef:scriptText>End If</gef:scriptText>\n" +
    "        <gef:scriptText>blnFetch = False</gef:scriptText>\n" +
    "        <gef:scriptText>blnContinous = False</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.SetWriteContinous blnContinous</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.Slider1.Min = CInt(dblLow)</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.Slider1.Max = CInt(dblHigh)</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.GetTheVars A:=1, B:=\"Fix32.FIX.BLACKY.F_CV\"</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.lblLow.Caption = dblLow</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.lblHigh.Caption = dblHigh</gef:scriptText>\n" +
    "        <gef:scriptText>Slider.Show</gef:scriptText>\n" +
    "        <gef:scriptText>End If</gef:scriptText>\n" +
    "        <gef:scriptText>Exit Sub</gef:scriptText>\n" +
    "        <gef:scriptText>ErrorHandler:</gef:scriptText>\n" +
    "        <gef:scriptText>HandleError</gef:scriptText>\n" +
    "        <gef:scriptText>End Sub</gef:scriptText>\n" +
    "        <gef:scriptText></gef:scriptText>\n" +
    "        <gef:scriptText>Private Sub Rect3_Click()</gef:scriptText>\n" +
    "        <gef:scriptText>'Poniższe komentarze zostały dodane automatycznie.</gef:scriptText>\n" +
    "        <gef:scriptText>'Jakiekolwiek zmiany mogą zmniejszyć funkcjonalność</gef:scriptText>\n" +
    "        <gef:scriptText>'Ekspertów autoryzacji skryptów.</gef:scriptText>\n" +
    "        <gef:scriptText>'WizardName=WprowadzanieDanych</gef:scriptText>\n" +
    "        <gef:scriptText>On Error GoTo ErrorHandler</gef:scriptText>\n" +
    "        <gef:scriptText>If blnDataEntryFrmFlag = True Then</gef:scriptText>\n" +
    "        <gef:scriptText>Exit Sub</gef:scriptText>\n" +
    "        <gef:scriptText>End If</gef:scriptText>\n" +
    "        <gef:scriptText>GetFormPushbutton</gef:scriptText>\n" +
    "        <gef:scriptText>Dim strOpenButton As String</gef:scriptText>\n" +
    "        <gef:scriptText>Dim strCloseButton As String</gef:scriptText>\n" +
    "        <gef:scriptText>Dim dblLow As Double</gef:scriptText>\n" +
    "        <gef:scriptText>Dim dblHigh As Double</gef:scriptText>\n" +
    "        <gef:scriptText></gef:scriptText>\n" +
    "        <gef:scriptText>dblLow = 0</gef:scriptText>\n" +
    "        <gef:scriptText>dblHigh = 1</gef:scriptText>\n" +
    "        <gef:scriptText>strOpenButton = \"relay_on\"</gef:scriptText>\n" +
    "        <gef:scriptText>strCloseButton = \"relay_off\"</gef:scriptText>\n" +
    "        <gef:scriptText>Pushbutton.GetTheVars A:=1, B:=\"Fix32.FIX.GREEN.F_CV\"</gef:scriptText>\n" +
    "        <gef:scriptText></gef:scriptText>\n" +
    "        <gef:scriptText>Pushbutton.cmdOpen.Caption = strOpenButton</gef:scriptText>\n" +
    "        <gef:scriptText>Pushbutton.cmdClose.Caption = strCloseButton</gef:scriptText>\n" +
    "        <gef:scriptText></gef:scriptText>\n" +
    "        <gef:scriptText>Pushbutton.cmdOk.SetFocus</gef:scriptText>\n" +
    "        <gef:scriptText></gef:scriptText>\n" +
    "        <gef:scriptText>Pushbutton.Show</gef:scriptText>\n" +
    "        <gef:scriptText>Exit Sub</gef:scriptText>\n" +
    "        <gef:scriptText></gef:scriptText>\n" +
    "        <gef:scriptText>ErrorHandler:</gef:scriptText>\n" +
    "        <gef:scriptText>HandleError</gef:scriptText>\n" +
    "        <gef:scriptText>End Sub</gef:scriptText>\n" +
    "    </gef:script>\n" +
    "</svg>\n";
}

    }
}