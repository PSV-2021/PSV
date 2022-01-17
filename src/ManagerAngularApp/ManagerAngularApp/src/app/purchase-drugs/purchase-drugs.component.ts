import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PharmacyDto } from '../review/pharmacy.dto';
import { PharmacyService } from '../services/pharmacy.service';
import { DrugstoreSearchDto } from './drugstore.search.dto';

@Component({
  selector: 'app-purchase-drugs',
  templateUrl: './purchase-drugs.component.html',
  styleUrls: ['./purchase-drugs.component.css']
})
export class PurchaseDrugsComponent implements OnInit {
  public selectedPharmacy: PharmacyDto;
  public pharmacies: PharmacyDto[];
  public searchInput: DrugstoreSearchDto;
  public drugAmount: number;
  public drugName: string;
  public disableButton: boolean;

  constructor(private pharmacyService: PharmacyService, private toastr: ToastrService) {
    this.selectedPharmacy = new PharmacyDto();
    this.searchInput = new DrugstoreSearchDto();
    this.pharmacies = [];
    this.drugName = '';
    this.drugAmount = 1;
    this.disableButton = true;
   }



   ngOnInit(): void {
    this.pharmacyService.GetAllDrugstores().subscribe((data: any) =>{
      console.log(data);
      for(const p of (data as any)){
        this.pharmacies.push({
          "Id": p.id,
          "Name": p.name,
          "Url": p.url,
          "Country": p.address.country,
          "City": p.address.city,
          "Address": p.address.street
        });
      }
    },
    error => {
      if(error.error)
        this.toastr.error(error.error, 'Sorry');
      else
        this.toastr.error(error, 'Sorry');
    });
  }

  public sendDemand(): void{
    if(!Number.isInteger(this.drugAmount)){
      alert("Drug amount must be whole number!");
      return;
    }
      
    this.pharmacyService.SendDrugDemand(this.selectedPharmacy.Url, this.drugAmount, this.drugName).subscribe((d: any) =>{
      if (d){
        this.disableButton = false;
        alert("You CAN order this drug from this drugstore.");
      }else if(!d){
        this.disableButton = true;
        alert("You CAN'T order this drug from this drugstore.");
      }

    },
    error => {
      if(error.error)
      this.toastr.error(error.error, 'Sorry');
      else
      this.toastr.error(error, 'Sorry');
    });
  }

  public sendUrgedPurchase(): void{
    this.pharmacyService.SendUrgentDrugPurchase(this.selectedPharmacy.Url, this.drugAmount, this.drugName).subscribe((d: any) =>{
      this.disableButton = true;
      if (d){
        alert("You have successfully purchased drugs!");
      }else if(!d){
        alert("Something went wrong!");
      }
    },
    error => {
      if(error.error)
      this.toastr.error(error.error, 'Sorry');
      else
      this.toastr.error(error, 'Sorry');
    });
  }

  public sendFilter(): void{
    this.pharmacyService.SendFilter(this.searchInput).subscribe((data: any) =>{
      console.log(data);
      this.pharmacies = [] as PharmacyDto[];
      for(const p of (data as any)){
        this.pharmacies.push({
          "Id": p.id,
          "Name": p.name,
          "Url": p.url,
          "Country": p.address.country,
          "City": p.address.city,
          "Address": p.address.street
        });
      }
      this.disableButton = true;
    },
    error => {
      if(error.error)
      this.toastr.error(error.error, 'Sorry');
      else
      this.toastr.error(error, 'Sorry');
    });
  }

  inputChanged(e: any){
    this.disableButton = true;
  }

}
