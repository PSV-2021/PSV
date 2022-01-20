import { Component, OnInit } from '@angular/core';
import { ReviewDto } from './review.dto';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ReviewService } from '../services/review.service';
import { PharmacyDto } from './pharmacy.dto';
import { PharmacyService } from '../services/pharmacy.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  public reviews: ReviewDto[];
  public selectedPharmacy: PharmacyDto;
  public pharmacies: PharmacyDto[];
  public review: string;
  constructor(private reviewService: ReviewService, private pharmacyService: PharmacyService, private toastr: ToastrService) {
    this.reviews = [
    ];
    this.selectedPharmacy = new PharmacyDto();
    this.pharmacies = [];
    this.review = "";
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

    this.reviewService.GetAllReviews().subscribe((data: any) => {
      for (const d of (data as any)) {
        console.log(d);
        this.reviews.push({
          "DrugstoreName": d.drugstoreName,
          "ReviewContent": d.content,
          "ReviewResponse": d.response,
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

  public sendReview(): void{
    this.reviewService.SendNewReview(this.selectedPharmacy.Id, this.review).subscribe((d: any) =>{
      this.reviews.push({
        "DrugstoreName": d.drugstoreName,
        "ReviewContent": d.content,
        "ReviewResponse": d.response,
      });
    }, error => {
      if(error.error)
      this.toastr.error(error.error, 'Sorry');
      else
      this.toastr.error(error, 'Sorry');
    });
  }

}
