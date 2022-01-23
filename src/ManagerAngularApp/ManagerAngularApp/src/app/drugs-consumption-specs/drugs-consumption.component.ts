import { Component, OnInit } from '@angular/core';
import { PharmacyDto } from '../review/pharmacy.dto';
import { DrugConsumptionSpecsService } from '../services/drug consumption specs.service';
import { FormControl, FormGroup} from '@angular/forms'
import { ToastrService } from 'ngx-toastr';


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
  

  constructor(private drugConsumptionSpecsService: DrugConsumptionSpecsService, private toastr: ToastrService) {
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
          "City": p.address.city,
          "Country": p.address.country,
          "Address": p.address.street
        });
      }
      this.range.value.start = null;
      this.range.value.end = null;
    },
    error => {
      if(error.error)
        this.toastr.error(error.error, 'Sorry');
      else
        this.toastr.error(error, 'Sorry');
    });
  }

  public requestDrugSpecification(): void{
    let filename = '';
    this.drugConsumptionSpecsService.RequestDrugSpecification(this.selectedPharmacy.Url, this.drugName).subscribe((d: any) =>{
      if (d){
        filename = this.drugName.charAt(0).toUpperCase() + this.drugName.slice(1).toLowerCase();
        this.toastr.info(filename + ' - Specifikacija leka.pdf has been recieved !', 'New file alert');
      }else if(!d){
        alert("Drugstore doesn't have requested drug specification for that drug.");
      }
    });
  }

  public generateReport(): void{
    if (this.isDateRangeIncorrect() || this.checkNulls()){
      alert("Report can't be generated for this date range. Please, pick a valid date range.");
    }
    else {
      this.drugConsumptionSpecsService.GenerateReport(this.range.value.start, this.range.value.end).subscribe((d: any) => {
        alert("Your drug consumption report has been generated successfully !");
      },
      error => {
        if(error.error)
          this.toastr.error(error.error, 'Sorry');
        else
          this.toastr.error(error, 'Sorry');
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
