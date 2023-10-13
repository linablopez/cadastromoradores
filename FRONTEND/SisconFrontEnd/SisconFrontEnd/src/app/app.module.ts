import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { HomeComponent } from './component/home/home.component';
import { LoginService } from './services/login.service';
import { AppRoutingModule } from './app-routing.module';
import { ApartamentoComponent } from './component/apartamento/apartamento.component';
import { LoginComponent } from './component/login/login.component';
import { NavBarComponent } from './component/nav-bar/nav-bar.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CurrencyMaskModule } from "ng2-currency-mask";
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatTabsModule } from '@angular/material/tabs';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatMenuModule } from '@angular/material/menu';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatRadioModule } from '@angular/material/radio';
import { MatDatepickerModule } from '@angular/material/datepicker'
import { MatNativeDateModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { CustomPaginatorIntl } from './componentCustom/CustomPaginatorIntl';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { SideNavBarComponent } from './component/side-nav-bar/side-nav-bar.component'
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatExpansionModule } from '@angular/material/expansion'
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ApartamentoDetalheComponent } from './component/apartamento-detalhe/apartamento-detalhe.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MoradorComponent } from './component/morador/morador.component';
import { MoradorDetalheComponent } from './component/morador-detalhe/morador-detalhe.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    ApartamentoComponent,
    NavBarComponent,
    SideNavBarComponent,
    ApartamentoDetalheComponent,
    MoradorComponent,
    MoradorDetalheComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    SlickCarouselModule,
    MatSelectModule,
    BrowserAnimationsModule,
    CurrencyMaskModule,
    MatButtonToggleModule,
    MatTabsModule,
    HttpClientModule,
    MatButtonModule,
    MatStepperModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatListModule,
    MatIconModule,
    MatMenuModule,
    MatAutocompleteModule,
    MatRadioModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule,
    MatCardModule,
    MatExpansionModule,
    MatSidenavModule,
    MatTableModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatTooltipModule
  ],
  providers: [
    LoginService,
    { provide: MatPaginatorIntl, useClass: CustomPaginatorIntl },
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
