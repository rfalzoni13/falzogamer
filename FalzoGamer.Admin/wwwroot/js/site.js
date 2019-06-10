// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    var ctx = $('#areaChart').get(0).getContext('2d');
    var areaChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho'],
            datasets: [{
                label: 'Consoles',
                data: [10, 25, 15, 5, 30, 35, 20],
                backgroundColor: [
                    'rgba(10, 23, 157, 0.3)'
                ],
                borderColor: [
                    'rgba(7, 14, 83, 1)'
                ],
                borderWidth: 1,
                lineTension: 0,
                fill: false
            },
            {
                label: 'Jogos',
                data: [12, 19, 3, 5, 2, 3, 22],
                backgroundColor: [
                    'rgba(32, 168, 25, 0.3)'
                ],
                borderColor: [
                    'rgba(17, 99, 12, 1)'
                ],
                borderWidth: 1,
                lineTension: 0,
                fill: false
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            },
            elments: {
                line: {
                    tension: 0
                }
            },
            responsive: true
        }
    });
});