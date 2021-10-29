import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatTabsModule } from "@angular/material/tabs";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatToolbarModule } from "@angular/material/toolbar";
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatNativeDateModule} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatIconModule} from '@angular/material/icon';
import {MatRadioModule} from '@angular/material/radio';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';

@NgModule({
    declarations: [],
    imports: [
      CommonModule,
      MatTabsModule,
      MatSidenavModule,
      MatToolbarModule,
      MatFormFieldModule,
      MatNativeDateModule,
      MatInputModule,
      MatSelectModule,
      MatIconModule,
      MatRadioModule,
      MatGridListModule,
      MatCardModule,
    ],
    exports: [
        MatTabsModule,
        MatSidenavModule,
        MatToolbarModule,
        MatFormFieldModule,
        MatNativeDateModule,
        MatInputModule,
        MatSelectModule,
        MatIconModule,
        MatRadioModule,
        MatGridListModule,
        MatCardModule,
    ]
})

export class MaterialModule { }