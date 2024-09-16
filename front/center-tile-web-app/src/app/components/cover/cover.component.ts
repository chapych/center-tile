import {Component, ViewContainerRef} from '@angular/core';
import {AngularYandexMapsModule, YaEvent, YaReadyEvent} from 'angular8-yandex-maps';
import {DropDownComponent} from "../drop-down/drop-down.component";
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {F} from "@angular/cdk/keycodes";

@Component({
  selector: 'app-cover',
  standalone: true,
  imports: [AngularYandexMapsModule, DropDownComponent, ReactiveFormsModule],
  templateUrl: './cover.component.html',
  styleUrl: './cover.component.css'
})
export class CoverComponent {
  map!: ymaps.Map;
  polygon = {
    feature: {
      geometry: {
        type: 'LineString',
        coordinates: []
      }
    },
    options: null as any
  };
  editor: ymaps.IGeometryEditor | undefined;

  onMapReady(event: YaReadyEvent<ymaps.Map>): void {
    this.map = event.target;
  }

  onPolygonReady(event: YaReadyEvent<ymaps.GeoObject>): void {
    const {target} = event;
    this.editor = target.editor;

    this.polygon.options = {
      editorDrawingCursor: 'crosshair',
      editorMaxPoints: 5,
      fillColor: '#00FF00',
      strokeColor: '#0000FF',
      strokeWidth: 10
    };
    const stateMonitor = new ymaps.Monitor(target.editor.state);

    stateMonitor.add('drawing', function (newValue) {
      target.options.set('strokeColor', newValue ? '#FF0000' : '#0000FF');
      target.options.set('strokeWidth', 10);
    });
    (target.editor as any).startDrawing();
  }

  public getCoordinates(): number[][] {
    const coordinates = (this.map.geoObjects.get(0).geometry as any).getCoordinates();
    return coordinates;
  }

  public removeCoordinates() {
    const coordinates = (this.map.geoObjects.get(0) as any);
    this.map.geoObjects.remove(coordinates);
  }

  public onButtonReady(event: YaReadyEvent<ymaps.control.Button>) {
    const { target } = event;
    target.events.add('click', (event)=> {
      this.map.geoObjects.remove(this.map.geoObjects.get(0));

      this.polygon = {
        feature: {
          geometry: {
            type: 'LineString',
            coordinates: [
            ],
          }
        },
        options: null as any
      };

      this.polygon.options = {
        editorDrawingCursor: 'crosshair',
        editorMaxPoints: 5,
        fillColor: '#00FF00',
        strokeColor: '#0000FF',
        strokeWidth: 10
      };
      const stateMonitor = new ymaps.Monitor(this.editor!.state);

      stateMonitor.add('drawing', function (newValue) {
        target.options.set('strokeColor', newValue ? '#FF0000' : '#0000FF');
        target.options.set('strokeWidth', 10);
      });
      (this.editor as any).startDrawing();
    })
  }
}
