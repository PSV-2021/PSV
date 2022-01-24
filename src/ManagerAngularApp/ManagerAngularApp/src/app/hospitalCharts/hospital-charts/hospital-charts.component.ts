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
  public chartCountInfo: any
  public chartNames: string[]
  public chartDays: string[]
  constructor(private eventStatisticsService: EventStatisticsService) {
    this.chartNames = ["Successful","First Step","Second Step","Not successful"]
    this.chartDays = ["Two days ago","Yesterday","Today"]
   }

  ngOnInit(): void {
    this.getChartInfo();
  }

  getChartInfo(): void {
    this.chartInfo = [];
    this.chartCountInfo = [];
    this.eventStatisticsService.getSucceedQuitRatio().subscribe((data: any) =>{
        console.log(data);
        for (var value of data)     {
             this.chartInfo.push(value);
        }
        this.makeWinsChart();
      });
      this.eventStatisticsService.getCreatedCount().subscribe((data: any) =>{
        console.log(data);
        for (var value of data)     {
             this.chartCountInfo.push(value);
        }
        this.makeCountSuccessChart();
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
          }  }
  });
  }
  makeCountSuccessChart(): void {
    var myWinsChart = new Chart('countSuccess', {
      type: 'bar',
      data: {
          labels: this.chartDays,
          datasets: [{
              label: "",
              data: this.chartCountInfo,
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
          }  }
  });
  }

}
