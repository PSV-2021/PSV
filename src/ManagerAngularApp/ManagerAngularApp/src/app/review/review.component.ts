import { Component, OnInit } from '@angular/core';
import { ReviewDto } from './review.dto';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { ReviewService } from '../services/review.service';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  public reviews: ReviewDto[];
  constructor(private reviewService: ReviewService) {
    this.reviews = [ 
      {"DrugstoreName" : "Ime apoteke 1", "ReviewContent" : "Ovo je bilo dobro1", "ReviewResponse": "Sram vas bilo1"},
      {"DrugstoreName" : "Ime apoteke 2", "ReviewContent" : "Ovo je bilo dobro2", "ReviewResponse": "Sram vas bilo2"},
      {"DrugstoreName" : "Ime apoteke 3", "ReviewContent" : "Ovo je bilo dobro3", "ReviewResponse": "Sram vas bilo3"},
    ];
   }

  ngOnInit(): void {
    this.reviewService.GetAllReviews().subscribe((data: any) => {
      for (const d of (data as any)) {
        this.reviews.push({
          "DrugstoreName": "Nemam u bazi...",
          "ReviewContent": d.content,
          "ReviewResponse": d.response,
        });
      }
    });
  }

}
