import { Component, OnInit } from '@angular/core';
import { PharmacyDto } from '../review/pharmacy.dto';
import { DrugConsumptionSpecsService } from '../services/drug consumption specs.service';
import { FormControl, FormGroup} from '@angular/forms'


@Component({
  selector: 'app-drugs-consumption',
  templateUrl: './drugs-consumption.component.html',
  styleUrls: ['./drugs-consumption.component.css']
})
export class DrugsConsumptionComponent implements OnInit {
  public selectedPharmacy: PharmacyDto;
  public pharmacies: PharmacyDto[];
  public drugName: string;
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });
  

  constructor(private drugConsumptionSpecsService: DrugConsumptionSpecsService) {
    this.selectedPharmacy = new PharmacyDto();
    this.pharmacies = [];
    this.drugName = '';
   }

   ngOnInit(): void {
    this.drugConsumptionSpecsService.GetAllDrugstores().subscribe((data: any) =>{
      console.log(data);
      for(const p of (data as any)){
        this.pharmacies.push({
          "Id": p.id,
          "Name": p.name,
          "Url": p.url,
          "City": p.city,
          "Address": p.address
        });
      }
      this.range.value.start = null;
      this.range.value.end = null;
    });
  }

  public openSpec(): void{
    var URL = "http://localhost:8887/Brufen - Specifikacija leka.pdf";
    window.open(URL, '_blank');
  }

  public requestDrugSpecification(): void{
    this.drugConsumptionSpecsService.RequestDrugSpecification(this.selectedPharmacy.Url, this.drugName).subscribe((d: any) =>{
      if (d){
        alert("Your request has been sent successfully !");
      }else if(!d){
        alert("Drugstore doesn't have requested drug specification for that drug.");
      }

    });
  }

  public generateReport(): void{
    if (this.isDateRangeIncorrect() || this.checkNulls()){
      alert("Report can't be generated for this date range. Please, pick a valid date range.");
      console.log(this.range);
    }
    else {
      this.drugConsumptionSpecsService.GenerateReport(this.range.value.start, this.range.value.end).subscribe((d: any) =>{
          alert("Your drug consumption report has been generated successfully !");
    });
  }
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

}
