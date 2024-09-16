import { Coordinate } from "./coordinate";

export interface DataSuggestion {
  coordinates: Coordinate[]
  material: string;
  email: string;
  comment: string
}
