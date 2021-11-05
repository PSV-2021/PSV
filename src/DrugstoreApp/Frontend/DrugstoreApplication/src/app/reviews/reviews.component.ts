import { Component, OnInit } from '@angular/core';
import { ReviewDto } from './review.dto';
import { ReviewsService } from '../services/review.service';
import { ResponseDto } from './response.dto';


@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {
  public reviews: ReviewDto[];
  public response: string;
  constructor(private reviewsService: ReviewsService) { 
    this.reviews = [ 
      {"Id" : 1, "HospitalName" : "Ime bolnice 1", "ReviewContent" : "Ovo je bilo dobro1", "ReviewResponse": "Sram vas bilo1"},
      {"Id" : 1, "HospitalName" : "Ime bolnice 2", "ReviewContent" : "Ovo je bilo dobro2", "ReviewResponse": "Sram vas bilo2"},
      {"Id" : 1, "HospitalName" : "Ime bolnice 3", "ReviewContent" : "Ovo je bilo dobro3", "ReviewResponse": "Sram vas bilo3"},
    ];
    this.response = "";
  }

  respond(review : ReviewDto): void {
    console.log(this.response);
    this.reviewsService.SendResponse(this.response, review).subscribe((d: any) =>{alert("NAJJACI" + d.response)});
  }
  ngOnInit(): void {
    this.reviewsService.GetAllMyReviews().subscribe((data: any) => {
      for (const d of (data as any)) {
        this.reviews.push({
          "Id": d.Id,
          "HospitalName": d.hospitalName,
          "ReviewContent": d.content,
          "ReviewResponse": d.response,
        });
      }
    });
  }

}
