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
  public response: ResponseDto;
  constructor(private reviewsService: ReviewsService) { 
    this.reviews = [ 
      {"HospitalName" : "Ime bolnice 1", "ReviewContent" : "Ovo je bilo dobro1", "ReviewResponse": "Sram vas bilo1"},
      {"HospitalName" : "Ime bolnice 2", "ReviewContent" : "Ovo je bilo dobro2", "ReviewResponse": "Sram vas bilo2"},
      {"HospitalName" : "Ime bolnice 3", "ReviewContent" : "Ovo je bilo dobro3", "ReviewResponse": "Sram vas bilo3"},
    ];
    this.response = new ResponseDto;
  }

  respond(): void {
    console.log(this.response);
    this.reviewsService.SendResponse(this.response).subscribe(responsy => alert("NAJJACI " + responsy));
  }
  ngOnInit(): void {
    // this.reviewsService.GetAllReviews().subscribe((data: any) => {
    //   for (const d of (data as any)) {
    //     this.reviews.push({
    //       "HospitalName": "Nemam u bazi...",
    //       "ReviewContent": d.content,
    //       "ReviewResponse": d.response,
    //     });
    //   }
    // });
  }

}
