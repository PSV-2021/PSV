import { Component, OnInit } from '@angular/core';
import { EventStatisticsService } from 'src/app/services/event-statistics.service';
import { Chart, ChartLayoutOptions } from 'chart.js';

@Component({
  selector: 'app-hospital-charts',
  templateUrl: './hospital-charts.component.html',
  styleUrls: ['./hospital-charts.component.css']
})
export class HospitalChartsComponent implements OnInit {
  public chartInfo: any
  public chartNames: string[]
  constructor(private eventStatisticsService: EventStatisticsService) {
    this.chartNames = ["Successful","First Step","Second Step","Not successful"]
   }

  ngOnInit(): void {
    this.getChartInfo();
  }
  getChartInfo(): void {
    this.chartInfo = [];
    this.eventStatisticsService.getSucceedQuitRatio().subscribe((data: any) =>{
        console.log(data);
        for (var value of data)     {
             this.chartInfo.push(value);
        }
        this.makeWinsChart();
      });
      
  }
  makeWinsChart(): void {
    var myWinsChart = new Chart('winsChart', {
      type: 'bar',
      data: {
          labels: this.chartNames,
          datasets: [{
              label: "",
              data: this.chartInfo,
              backgroundColor: [
                'rgba(255, 99, 132, 0.7)',
                'rgba(54, 162, 235, 0.7)',
                'rgba(255, 206, 86, 0.7)',
                'rgba(75, 192, 192, 0.7)',
                'rgba(153, 102, 255, 0.7)',
                'rgba(255, 159, 64, 0.7)'
            ],
              borderColor: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(153, 102, 255, 1)',
                  'rgba(255, 159, 64, 1)'
              ],
              borderWidth: 1
          }]
      },
      options: {
         legend: { display: false } ,


          scales: {
            yAxes: [{
              ticks: {
                  beginAtZero: true
              }
          }]
          }
      }
  });
  }

}
