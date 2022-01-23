import { Component, OnInit } from '@angular/core';
import { DrugstoreOfferDto } from './drugstore-offer.dto';
import { DrugStoreOffersService } from '../services/drugstore-offer.service';
import { PublishedDrugstoreOfferDto } from './published-drugstore-offer.dto';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-drugstore-offers',
  templateUrl: './drugstore-offer.component.html',
  styleUrls: ['./drugstore-offer.component.css']
})
export class DrugstoreOfferComponent implements OnInit {
 public drugstoreOffers : DrugstoreOfferDto[];
 public publishedDrugstoreOffer: PublishedDrugstoreOfferDto;

  constructor(private drugStoreOffersService : DrugStoreOffersService, private toastr: ToastrService) { 
  this.drugstoreOffers = [] as DrugstoreOfferDto[];
  this.publishedDrugstoreOffer = new PublishedDrugstoreOfferDto;
  }
  ngOnInit(): void {
    this.drugStoreOffersService.GetAllOffers().subscribe((data: any) =>{
      console.log(data);
      for(const ds of (data as any)){
        this.drugstoreOffers.push({
          "Id": ds.id,
          "Content" : ds.content,
          "Title" : ds.title,
          "StartDate" : ds.startDate,
          "EndDate" : ds.endDate,
          "DrugstoreName": ds.drugstoreName,
          "IsPublished" : ds.isPublished,
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
  reloadPage() {
    window.location.reload();
  }
  async publishOffer(offer : PublishedDrugstoreOfferDto ):Promise<void> {
   await this.drugStoreOffersService.publishOffer(offer).subscribe((d: any) =>{alert("Offer published" );
    this.reloadPage();
  });
    
    
}


}
