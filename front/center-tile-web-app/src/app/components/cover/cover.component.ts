import { Component } from '@angular/core';
import {AngularYandexMapsModule, YaReadyEvent} from 'angular8-yandex-maps';
import IGeoObjectOptions = ymaps.IGeoObjectOptions;

@Component({
  selector: 'app-cover',
  standalone: true,
  imports: [AngularYandexMapsModule],
  templateUrl: './cover.component.html',
  styleUrl: './cover.component.css'
})
export class CoverComponent {
  map!: ymaps.Map;

  polygon = {
    feature: {
      geometry: {
        // The "Polygon" geometry type.
        type: 'LineString',
        coordinates: [],
      },
      properties: {
        // The contents of the hint.
        hintContent: "I'm a geo object",
        // The contents of the balloon.
        balloonContent: 'You can drag me',
      },
    },
    options: null as any
  };

  onMapReady(event: YaReadyEvent<ymaps.Map>): void {
    this.map = event.target;
  }

  onPolygonReady(event: YaReadyEvent<ymaps.GeoObject>): void {
    const { target } = event;

    this.polygon.options = {
      // The cursor in the mode for adding new vertices.
      editorDrawingCursor: 'crosshair',
      // The maximum number of vertices.
      editorMaxPoints: 5,
      // Fill color.
      fillColor: '#00FF00',
      // Stroke color.
      strokeColor: '#0000FF',
      // The stroke width.
      strokeWidth: 1
    };

    const stateMonitor = new ymaps.Monitor(target.editor.state);

    stateMonitor.add('drawing', function (newValue) {
      target.options.set('strokeColor', newValue ? '#FF0000' : '#0000FF');
      target.options.set('strokeWidth', 10);
    });

    // Turning on the edit mode with the possibility of adding new vertices.
    // Casting is needed, see https://github.com/ddubrava/angular8-yandex-maps/issues/135
    (target.editor as any).startDrawing();
  }
}
