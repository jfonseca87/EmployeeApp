Employee App

Table of Contents

    Introduction
    Architecture Overview
    Technologies Used
    Getting Started
    API Endpoints
    Frontend Setup
    Running the Application
    Contributing
    License

Introduction

This project is a web application that uses a .NET API built with minimal APIs and follows a clean architecture approach.
The frontend is built with React, focusing on simplicity and ease of use.
Architecture Overview

The application follows a clean architecture to maintain separation of concerns and promote testability. Unlike traditional implementations, this project avoids DDD, CQRS, and MediatR to reduce unnecessary complexity.
Layers

    API Layer: Implements the minimal API endpoints.
    Application Layer: Contains business logic and service interfaces.
    Infrastructure Layer: Deals with data access and external services.
    Domain Layer: Contains core business models and logic (simplified, without DDD).

Technologies Used

    Backend:
        .NET 8 (minimal APIs)
    Frontend:
        React
        Bootstrap (for styling)

Getting Started

Prerequisites
    .NET 8 SDK
    Node.js (v14 or later)
    npm (or yarn)

Running the Application

Backend
To run the .NET API:
cd src/YourApiProject
dotnet run

Frontend
To start the React application:
cd src/YourReactApp
npm start

This will launch the frontend on http://localhost:3000 and the backend on http://localhost:5000.
