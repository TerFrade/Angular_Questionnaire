import 'bootstrap/dist/css/bootstrap.css';
import 'es6-promise';
import 'es6-shim';
import 'reflect-metadata';
import 'zone.js/dist/zone.js';
import 'zone.js/dist/long-stack-trace-zone';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app.module';

declare const IS_DEV_BUILD: boolean;

if (!IS_DEV_BUILD) { enableProdMode(); }
const modulePromise = platformBrowserDynamic().bootstrapModule(AppModule);
