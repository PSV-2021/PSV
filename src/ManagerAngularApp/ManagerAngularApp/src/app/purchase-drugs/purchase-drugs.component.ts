import { Component, OnInit } from '@angular/core';
import { PharmacyDto } from '../review/pharmacy.dto';
import { PharmacyService } from '../services/pharmacy.service';

@Component({
  selector: 'app-purchase-drugs',
  templateUrl: './purchase-drugs.component.html',
  styleUrls: ['./purchase-drugs.component.css']
})
export class PurchaseDrugsComponent implements OnInit {
  public selectedPharmacy: PharmacyDto;
  public pharmacies: PharmacyDto[];
  public drugAmount: number;
  public drugName: string;

  constructor(private pharmacyService: PharmacyService) {
    this.selectedPharmacy = new PharmacyDto();
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
          "Url": p.url
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

}
