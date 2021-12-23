import { Component, OnInit } from '@angular/core';
import { TenderDto } from './tender.dto';
import { FormControl, FormGroup} from '@angular/forms'
import { validateHorizontalPosition } from '@angular/cdk/overlay';
import { TenderService } from '../services/tender.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-tender',
  templateUrl: './tender.component.html',
  styleUrls: ['./tender.component.css']
})
export class TenderComponent implements OnInit {
  public tenderItems: TenderDto[];
  public newTender: TenderDto;
  public tenderEnd = new Date();

  constructor(private tenderService: TenderService, private toastr: ToastrService) { 
    this.tenderItems = [];
    this.newTender = new TenderDto();
  }

  ngOnInit(): void {
    this.tenderEnd.setDate(this.tenderEnd.getDate() + 10)
  }

  valid(): boolean {
    if (this.newTender.Amount < 1 || this.newTender.DrugName.trim() == "")
      return false;
    return true;
  }

  notRepeat(drugname: string): boolean {
    let name2 = drugname.trim().toLowerCase();
    for (let i = 0; i < this.tenderItems.length; i++){
      let name1 = this.tenderItems[i].DrugName.trim().toLowerCase();
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
        item.DrugName = this.newTender.DrugName;
        item.Amount = Math.floor(this.newTender.Amount); 
        this.tenderItems.push(item);
        this.newTender.DrugName = "";
        this.newTender.Amount = 1;
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
      if (this.tenderItems[i].DrugName == drugname) {
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

}
