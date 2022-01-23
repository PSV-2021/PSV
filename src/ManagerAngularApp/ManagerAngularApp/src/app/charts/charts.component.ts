import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
//@ts-ignore
import { Chart } from 'node_modules/chart.js';
import { ChartsInfoDto } from './charts-info.dto';
import { ChartService } from '../services/chart.service';
import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y/input-modality/input-modality-detector';
import jsPDF from 'jspdf';
import { debounceTime } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-charts',
  templateUrl: './charts.component.html',
  styleUrls: ['./charts.component.css']
})
export class ChartsComponent implements OnInit {
    public chartInfo: ChartsInfoDto[]
    public chartNames: string[]
    public chartWins: number[]
    public chartParticipations: number[]
    public chartProfit: number[]
    public myWinsChart: Chart
    public myParticipationsChart: Chart
    public myProfitChart: Chart
    range = new FormGroup({
        start: new FormControl(),
        end: new FormControl(),
      });
    
  constructor(private chartService: ChartService, private toastr: ToastrService) {
      this.chartInfo = [];
      this.chartNames = [];
      this.chartWins = [];
      this.chartParticipations = [];
      this.chartProfit = [];
   }

  ngOnInit(): void {
    this.range.value.start = new Date(2020,1,1);
    this.range.value.end = new Date(2025,1,1);
    this.getChartInfo();
    setTimeout(() => {
      this.formatChartInfo();
      this.makeWinsChart();
      this.makeProfitChart();
      this.makeParticipationsChart();
  }, 500);
  }

  public updateCharts(): void{
    if (this.isDateRangeIncorrect() || this.checkNulls()){
      alert("Report can't be updated for this date range. Please, pick a valid date range.");
    }
    else {
      this.getChartInfo();
      setTimeout(() => {
        this.formatChartInfo();
      }, 50);
      setTimeout(() => {
        this.formatChartInfo();
        this.makeWinsChart();
        this.makeProfitChart();
        this.makeParticipationsChart();
      }, 500);
      alert("Your drugstore tender chart has been updated successfully !");
    }
    
  }

  public generateReport(): void{
    if (this.isDateRangeIncorrect() || this.checkNulls()){
      alert("Report can't be generated for this date range. Please, pick a valid date range.");
    }
    else {
        this.updateCharts();
        setTimeout(() => {
          this.generateAndOpenPDF();
      }, 1500);
        //alert("Your drugstore tender report has been generated successfully !");
    }
  }

  public generateAndOpenPDF(): void {
    const winsCanvas = document.getElementById('winsChart') as HTMLCanvasElement
        const participationsCanvas = document.getElementById('participationsChart') as HTMLCanvasElement
        const profitCanvas = document.getElementById('profitChart') as HTMLCanvasElement
        //image creation
        const winsImage = winsCanvas.toDataURL('image/jpeg', 1.0);
        const participationsImage = participationsCanvas.toDataURL('image/jpeg', 1.0);
        const profitImage = profitCanvas.toDataURL('image/jpeg', 1.0);
        let pdf = new jsPDF('landscape'); 
        pdf.setFontSize(20);
        pdf.text('Tender charts - ', 80, 10);
        pdf.text(this.range.value.start.toString().substring(4,15) + ' - ' + this.range.value.end.toString().substring(4,15), 130, 10);
        pdf.text('Drugstore tender wins', 110, 25);
        pdf.addImage(winsImage, 'JPEG', 60, 65, 180, 100);
        pdf.addPage();
        pdf.text('Drugstore tender profit', 110, 15);
        pdf.addImage(profitImage, 'JPEG', 60, 55, 180, 100);
        pdf.addPage();
        pdf.text('Drugstore tender participations', 110, 15);
        pdf.addImage(participationsImage, 'JPEG', 60, 55, 180, 100);
        pdf.save('Tender_charts - ' + this.range.value.start.toString().substring(4,15) + ' - ' + this.range.value.end.toString().substring(4,15) + '.pdf');
        window.open(URL.createObjectURL(pdf.output("blob")))
      }


  public checkNulls(): boolean
  {
      if (this.range.value.start == null || this.range.value.end == null)
      {
        return true;
      }
      else
        return false;
  }

  public isDateRangeIncorrect(): boolean
  {
      if (this.range.value.start > this.range.value.end)
      {
        return true;
      }
      else
        return false;
  }
  
  makeWinsChart(): void {
    if (this.myWinsChart) {
      this.myWinsChart.destroy()
    }
    this.myWinsChart = new Chart('winsChart', {
      type: 'bar',
      data: {
          labels: this.chartNames,
          datasets: [{
              label: 'Amount of wins',
              data: this.chartWins,
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

  makeProfitChart(): void {
    if (this.myProfitChart) {
      this.myProfitChart.destroy()
    }
    this.myProfitChart = new Chart('profitChart', {
      type: 'bar',
      data: {
          labels: this.chartNames,
          datasets: [{
              label: 'Total profit',
              data: this.chartProfit,
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

  makeParticipationsChart(): void {
    if (this.myParticipationsChart) {
      this.myParticipationsChart.destroy()
    }
    this.myParticipationsChart = new Chart('participationsChart', {
      type: 'bar',
      data: {
          labels: this.chartNames,
          datasets: [{
              label: 'Number of participations',
              data: this.chartParticipations,
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

  formatChartInfo(): void {
    this.chartNames = [];
    this.chartWins = [];
    this.chartParticipations = [];
    this.chartProfit = [];
    for (let i = 0; i < this.chartInfo.length; i++){
        this.chartNames.push(this.chartInfo[i].DrugstoreName);
        this.chartParticipations.push(this.chartInfo[i].Participations);
        this.chartWins.push(this.chartInfo[i].Wins);
        this.chartProfit.push(this.chartInfo[i].Profit);
    }
    console.log(this.chartParticipations);
    console.log(this.chartWins);
    console.log(this.chartProfit);
    console.log(this.chartNames);
  }

  getChartInfo(): void {
    this.chartInfo = [];
    this.chartService.GetChartInfo(this.range.value.start, this.range.value.end).subscribe((data: any) =>{
      console.log(this.range.value)
        console.log(data);
        for(const ci of (data as any)){
          this.chartInfo.push({
            "DrugstoreId": ci.drugstoreId,
            "DrugstoreName": ci.drugstoreName,
            "Wins": ci.wins,
            "Profit" : ci.profit,
            "Participations": ci.participations
          });
        }
        console.log(this.chartInfo);
      },
      error => {
        if(error.error)
          this.toastr.error(error.error, 'Sorry');
        else
          this.toastr.error(error, 'Sorry');
      });
  }
}
