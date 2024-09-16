import {ChangeDetectionStrategy, Component, ViewChild} from '@angular/core';
import {MatSelectModule} from "@angular/material/select";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {FormControl, FormGroup, FormGroupDirective, NgForm, ReactiveFormsModule, Validators} from "@angular/forms";
import {ErrorStateMatcher} from "@angular/material/core";
import {MatButton} from "@angular/material/button";
import { CoverComponent } from '../cover/cover.component';
import { DataSuggestionsService } from '../../../services/data-suggestions/data-suggestions.service';
import { DataSuggestion } from '../../../models/datasuggestion';
import { Coordinate } from '../../../models/coordinate';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-cover-info',
  standalone: true,
  templateUrl: './cover-info.component.html',
  styleUrl: './cover-info.component.css',
  imports: [MatFormFieldModule, MatInputModule, MatSelectModule, ReactiveFormsModule, MatButton, CoverComponent],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CoverInfoComponent {
  info : FormGroup;
  @ViewChild('coverComponent') coverComponent!: CoverComponent;

  constructor(private dataSuggestionsService : DataSuggestionsService) {
    this.info = new FormGroup({
      "email": new FormControl('', [Validators.required, Validators.email]),
      "material-type": new FormControl(''),
      "comment": new FormControl(''),
      "coordinates": new FormControl([])
    });
  }
  matcher = new MyErrorStateMatcher();

  submit() {
    const coordinates = this.coverComponent.getCoordinates();
    if(coordinates == null || coordinates.length <=1){
      alert("Не забудьте отметить участок на карте :)")
    }
    else {
      this.info.get('coordinates')?.setValue(coordinates);

      const material = this.info.get('material-type')!.value;
      const email = this.info.get('email')!.value;
      const comment = this.info.get('comment')!.value;
      const convertedCoordinates = this.convertToCoordinates(coordinates);

      this.dataSuggestionsService.add({coordinates: convertedCoordinates, material, email, comment} as DataSuggestion)
      alert("Данные отправлены!");
    }
  }

  convertToCoordinates(arr: number[][]): Coordinate[] {
    return arr.map(([latitude, longitude]) => ({
      latitude,
      longitude
    }));
  }
}
