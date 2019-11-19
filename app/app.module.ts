import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';;
import { ClientSearchComponent } from './client-search/client-search.component';
import { SearchFormComponent } from './search-form/search-form.component';
import { SearchResultComponent } from './search-result/search-result.component';
import { HttpClientModule } from '@angular/common/http';
import { ClientServiceService } from './client-service.service';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ClientSearchComponent,
    SearchFormComponent,
    SearchResultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ClientServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
