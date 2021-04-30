# AzureToolKit

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 9.1.9.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

## commands

    ng generate interface common/models/bingSearchResponse
    ng generate interface common/models/ComputerVisionResponse
    ng generate interface common/models/ImagePostRequest
    ng generate interface common/models/SavedImage
    ng generate class common/models/User

    ng generate service common/services/AzureHttpClient
    ng generate service common/services/AzureToolkit
    ng generate service common/services/Cognitive
    ng generate service common/services/User

    ng generate component Counter
    ng generate component FetchData
    ng generate component Gallery
    ng generate component Home
    ng generate component NavMenu
    ng generate component Search

https://loiane.com/2017/08/how-to-add-bootstrap-to-an-angular-cli-project/
    npm install bootstrap@3.3.7 -> 3.4.1
    in angular.json add:
        "styles": [
        "node_modules/bootstrap/dist/css/bootstrap.min.css",
        "styles.scss"
        ]

## update commands
    npm install -g npm@latest
    npm install -g npm@next     // upgrade to the most recent release

    ng update
    ng update @angular/cli
    ng update @angular/core
    npm update
    npm install typescript@4.1.5
