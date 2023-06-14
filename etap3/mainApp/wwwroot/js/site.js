//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.

//function plotYearlyData(data) {
//    var dataPoints = [];
//var obj = JSON.parse(data);
//var stockChart = new CanvasJS.StockChart("chartContainer",
//{
//    backgroundColor: "#2d2c38",
//height: 800,
//title: {
//    text: "BTC/USD",
//fontSize: 30,
//fontColor: "white",
//padding: 5,
//borderThickness: 4,
//cornerRadius: 8,
//borderColor: "#3763f4",
//backgroundColor: "#3763f4",
//            },
//charts:
//[{
//    axisY:
//{
//    labelFontColor: "white",
//prefix: "$",
//title: "Price"
//                    },
//data:
//[{
//    type: "line",
//yValueFormatString: "$#,###.##",
//dataPoints: dataPoints
//                        }]
//                }],
//rangeSelector: {
//    buttons: [{
//    range: 1,
//rangeType: "day",
//label: "Day"
//                }, {
//    range: 1,
//rangeType: "year",
//label: "Year"
//                }],
//inputFields: {
//    startValue: new Date(2018, 03, 01),
//endValue: new Date(2018, 04, 31)
//                }
//            }
//        });
//$.getJSON("https://canvasjs.com/data/docs/btcusd2018.json", function (data) {
//        for (var i = 0; i < data.length; i++) {
//    dataPoints.push({ x: new Date(data[i].date), y: Number(data[i].close) });
//        }
//        //for (var i = 0; i < obj.length; i++) {
//    //    dataPoints.push({ x: new Date(obj[i].Dzien), y: Number(obj[i].Cena) });
//    //}
//    stockChart.render();
//    });
//}