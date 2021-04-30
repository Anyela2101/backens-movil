import { Examenes } from "./Examen";
import { Usuario } from "./usuario";

export class Persona {
    identificacion: string;
    nombres: string;
    apellidos: string;
    edad: number;
    sexo: string;
    telefono: string;
    email: string;
    estadoCivil: string;
    paisProcedencia: string;
    nivelEducativo: string;
    Idrestaurante:string;
    examenes: Array<Examenes>;
    usuario: Usuario;

    constructor() {
        this.examenes = [];
        this.usuario = new Usuario();
    }
}

