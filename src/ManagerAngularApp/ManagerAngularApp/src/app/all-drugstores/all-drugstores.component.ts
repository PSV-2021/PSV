import { Component, OnInit } from '@angular/core';
import { PharmacyService } from '../services/pharmacy.service';
import { DrugstoreWithImageDto } from './drugstore.with.image';

@Component({
  selector: 'app-all-drugstores',
  templateUrl: './all-drugstores.component.html',
  styleUrls: ['./all-drugstores.component.css']
})
export class AllDrugstoresComponent implements OnInit {
  public drugstores: DrugstoreWithImageDto[];

  constructor(private pharmacyService: PharmacyService) {
    this.drugstores = [];
   }

  ngOnInit(): void {
    this.pharmacyService.GetAllDrugstoresWithImage().subscribe((data: any) =>{
      console.log(data);
      for(const p of (data as any)){
        this.drugstores.push({
          "Id": p.id,
          "Name": p.name,
          "Url": p.url,
          "City": p.city,
          "Address": p.address,
          "Comment": p.comment,
          "ImageBase64": p.base64Image
        });
      }
    });
  }

}
