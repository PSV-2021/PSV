import { Component, OnInit } from '@angular/core';
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

  constructor(private pharmacyService: PharmacyService) {
    this.selectedPharmacy = new PharmacyDto();
    this.searchInput = new DrugstoreSearchDto();
    this.pharmacies = [];
    this.drugName = '';
    this.drugAmount = 1;
   }



   ngOnInit(): void {
    this.pharmacyService.GetAllDrugstores().subscribe((data: any) =>{
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
    });
  }

  public sendDemand(): void{
    this.pharmacyService.SendDrugDemand(this.selectedPharmacy.Url, this.drugAmount, this.drugName).subscribe((d: any) =>{
      if (d){
        alert("You CAN order this drug from this drugstore ");
      }else if(!d){
        alert("You CAN'T order this drug from this drugstore ");
      }

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
          "City": p.city,
          "Address": p.address
        });
      }
    });
  }

}
