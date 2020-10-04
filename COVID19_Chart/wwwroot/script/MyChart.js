function DrawLineChart(summaryListlast) {
    var datachart = {
        labels: [],
        datasets: [{
            label: '確診人數',
            data: [],
            borderColor: '#FF5376',
            fill: false
        }]
    };

    for (var i = 0; i < summaryListlast.length; i++) {
        datachart.labels.push(summaryListlast[i].shortDate);
        datachart.datasets[0].data.push(summaryListlast[i].confirmed);
    }

    var ctx = document.getElementById("myChart").getContext("2d");
    var chart = new Chart(ctx, {
        type: 'line',
        data: datachart,
    })
}