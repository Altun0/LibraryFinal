// Data for the chart
var myData = {
    type: "bar",
    series: [
        {
            values: [3,7,10,2,6,5]
        },
        {
            values: [5,6,2,10,7,3]
        },
        {
            values: [10,3,8,4,2,7]
        },
        {
            values: [9,8,7,6,5,4]
        },
        {
            values: [1,2,4,6,8,10]
        }

    ]
};

// Make your chart
$("#myChart").zingchart({
    data: myData
});

// Set a flag for toggling clicks
var hidden = false;

// Bind a double click event
$("#myChart").plotDoubleClick(function(){
    // If plots are hidden, show all plots.
    if (hidden) {
        $(this).showAllPlots();
    }
    // Otherwise, hide all plots but the one clicked.
    else {
        $(this).hideAllPlotsBut({
            plotindex:this.event.plotindex
        });
    }
    // Invert the hidden flag.
    hidden = !hidden;
});