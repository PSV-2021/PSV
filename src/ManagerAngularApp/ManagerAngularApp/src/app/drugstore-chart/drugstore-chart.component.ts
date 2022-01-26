import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
//@ts-ignore
import { Chart } from 'node_modules/chart.js';
import { ChartsInfoDto } from './charts-info.dto';
import { ChartService } from '../services/chart.service';
import { TOUCH_BUFFER_MS } from '@angular/cdk/a11y/input-modality/input-modality-detector';
import jsPDF from 'jspdf';
import { debounceTime } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';
import { TenderService } from '../services/tender.service';
import { TenderOfferDto } from './tender-offer.dto';
import { TenderDto } from '../tender/tender.dto';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-drugstore-chart',
  templateUrl: './drugstore-chart.component.html',
  styleUrls: ['./drugstore-chart.component.css']
})
export class DrugstoreChartComponent implements OnInit {
  public chartInfo: ChartsInfoDto
  public chartNames: string[]
  public chartWins: number
  public chartParticipations: number
  public chartProfit: number
  public myWinsChart: Chart
  public myParticipationsChart: Chart
  public myProfitChart: Chart 
  public id

  public offers: TenderOfferDto[]
  public prices: number[]
  public winAndP: number[]
    
  range = new FormGroup({
      start: new FormControl(),
      end: new FormControl(),
    });
    
  constructor(private chartService: ChartService, private route: ActivatedRoute, private tenderService: TenderService, private toastr: ToastrService) {
      this.chartInfo = new ChartsInfoDto();
      this.chartNames = [];
      this.winAndP = [];
      this.chartWins = 0;
      this.chartParticipations = 0;
      this.chartProfit = 0;
      this.id = 0;
      this.offers = [];
      this.prices = [] as number[];
      this.winAndP = [] as number[];
    }

  ngOnInit(): void {
    
    
    this.id = this.route.snapshot.params['id'];
    this.tenderService.GetAllOffersForDrugstore(this.id).subscribe((data: any) => {
      this.offers = data;  
    },
    error => {
      if(error.error)
        this.toastr.error(error.error, 'Sorry');
      else
        this.toastr.error(error, 'Sorry');
    }
    );
    
    this.range.value.start = new Date(2020,1,1);
    this.range.value.end = new Date(2025,1,1);
    this.getChartInfo();
    setTimeout(() => {
      this.formatChartInfo();
      this.makeWinsChart();
      this.makeProfitChart();
      //this.makeParticipationsChart();
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
      //this.makeParticipationsChart();
  }, 500);
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
              label: 'Prices',
              data: this.prices,
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
    this.myProfitChart = new Chart('profitsChart', {
      type: 'polarArea',
      data: {
          labels: ["winnings", "participations"],
          datasets: [{
              label: 'participations',
              data: this.winAndP,
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
    this.chartParticipations = this.chartInfo.participations;
    this.chartWins = this.chartInfo.wins;
    this.chartProfit = this.chartInfo.Profit;

    console.log(this.chartWins)
    this.winAndP.push(this.chartInfo.wins)
    this.winAndP.push(this.chartInfo.participations)
    console.log(this.winAndP)
    
    var idx = 1
     this.offers.forEach(offer => {
      this.prices.push(offer.price)
      this.chartNames.push(("Tender Offer "+ idx))
      idx += 1;
     })
    
  }

  getChartInfo(): void {
    this.chartInfo = new ChartsInfoDto();
    this.chartService.GetSingleChartInfo(this.range.value.start, this.range.value.end, this.id).subscribe((data: any) =>{
      console.log(this.range.value)
        console.log(data);
        
        this.chartInfo = ({
          "DrugstoreId": data.drugstoreId,
          "DrugstoreName": data.drugstoreName,
          "wins": data.wins,
          "Profit" : data.profit,
          "participations": data.participations
        });
      },
      error => {
        if(error.error)
          this.toastr.error(error.error, 'Sorry');
        else
          this.toastr.error(error, 'Sorry');
      });
  }
}
