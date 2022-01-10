import { Component, OnInit } from '@angular/core';
import { TenderDto } from './tender.dto';
import { FormControl, FormGroup} from '@angular/forms'
import { validateHorizontalPosition } from '@angular/cdk/overlay';
import { TenderService } from '../services/tender.service';
import { ToastrService } from 'ngx-toastr';
import { WholeTenderDto } from './whole.tender.dto';
import { Router } from '@angular/router';
//@ts-ignore
import { Chart } from 'node_modules/chart.js';

@Component({
  selector: 'app-tender',
  templateUrl: './tender.component.html',
  styleUrls: ['./tender.component.css']
})
export class TenderComponent implements OnInit {
  public tenderItems: TenderDto[];
  public ongoingTenders : WholeTenderDto[];
  public newTender: TenderDto;
  public tenderEnd = new Date();


  constructor(private tenderService: TenderService, private toastr: ToastrService, private router: Router) { 
    this.tenderItems = [];
    this.newTender = new TenderDto();
    this.ongoingTenders = [];
  }

  ngOnInit(): void {
    this.tenderEnd.setDate(this.tenderEnd.getDate() + 10);

    this.tenderService.GetAllActiveTenders().subscribe((data: any)=>{
      console.log(data);
      for(const p of (data as any)){
        this.ongoingTenders.push({
          "id": p.id,
          "tenderEnd": p.tenderEnd,
          "tenderInfo": p.tenderInfo
        });
      }
      console.log(this.ongoingTenders);
      
    });
  }

  valid(): boolean {
    if (this.newTender.amount < 1 || this.newTender.drugName.trim() == "")
      return false;
    return true;
  }

  notRepeat(drugname: string): boolean {
    let name2 = drugname.trim().toLowerCase();
    for (let i = 0; i < this.tenderItems.length; i++){
      let name1 = this.tenderItems[i].drugName.trim().toLowerCase();
      if (name1 == name2)
        return false;      
      }
    return true;  
  }

  addDrug(drugname: string): void {
    console.log(this.tenderEnd)
    if (this.valid()){
      if (this.notRepeat(drugname)){
        let item = new TenderDto();
        item.drugName = this.newTender.drugName;
        item.amount = Math.floor(this.newTender.amount); 
        this.tenderItems.push(item);
        this.newTender.drugName = "";
        this.newTender.amount = 1;
      }
      else
      this.toastr.error('You have already added that drug to tender !', 'Error');
    }
    else
      this.toastr.error('Please, fill drug name and amount with valid data !', 'Error');
  }

  removeDrug(drugname: string): void {
    let index = 0;
    for (let i = 0; i < this.tenderItems.length; i++){
      if (this.tenderItems[i].drugName == drugname) {
        index = i;
      }
    }
    this.tenderItems.splice(index, 1);
  }

  isTenderValid(): boolean {
    let now = new Date();
    now.setDate(now.getDate());
    console.log(now);
      if (this.tenderItems.length == 0 || this.tenderEnd == null || this.tenderEnd < now)
        return false;
    return true;
  }

  saveTender(): void {
    if (this.isTenderValid()) {
      this.tenderService.SaveTender(this.tenderEnd, this.tenderItems).subscribe((d: any) =>{
      this.toastr.success('Tender has been added successfully !', 'Tender');
      })
    }
    else 
      this.toastr.error('Your tender ending date must be valid (after today) and your drug list must contain at least one drug !', 'Error');
  }

  seeOffers(id: string){
    console.log(id);
    this.router.navigate(['offer/' + id]);
  }
}
