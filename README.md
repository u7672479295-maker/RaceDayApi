# RaceDay-Events-Management-System
1. System Overview

RaceDay is a full-stack, cloud-ready event management platform designed specifically for South Africa’s road running, walking, and cycling community. The platform is intended to support a wide range of events, from major races such as the Comrades Marathon, Soweto Marathon, and Two Oceans, to smaller community runs, park walks, and charity cycling events.

Many sporting events still rely on manual registration processes, separate Excel spreadsheets, and disconnected communication methods. These approaches can make it difficult to manage participant information, registrations, categories, and official results efficiently.

RaceDay addresses these challenges by providing a centralised and secure API-driven solution. The platform combines:

A normalised relational database for structured data management
A secure RESTful API for handling business logic and system operations
A responsive MVC web application for user interaction
Event registration and enrolment management
Dynamic age and distance category management
Secure participant information
Official race result and finishing-time capture

The overall goal is to provide event organisers and participants with a more reliable and streamlined way of managing road-based sporting events.

2. Role-Based Access Control

RaceDay uses Role-Based Access Control (RBAC) to separate administrative functionality from participant functionality. The system supports two main user roles, each with its own responsibilities and permissions.

🛠️ Event Organiser

The Event Organiser is responsible for managing the events and administrative operations within the platform.

Key responsibilities and permissions include:

Create, view, update, and delete sporting events
Manage event information and metadata
Create and manage age and distance Categories
Senior
Veteran
10 km
21 km
89 km
Capture, update, and publish official race results
Record participant finishing times and overall positions
Monitor active registrations and competitor enrolments

The Event Organiser therefore has the administrative authority required to manage an event from its initial setup through to the recording of final results.

🏃 Participant

The Participant represents the athlete taking part in a running, walking, or cycling event.

Key responsibilities and permissions include:

Create and manage a personal profile
Log in using secure role-based credentials
Browse upcoming sporting events
View available event categories and distances
Register for a selected event category
Track active event enrolments through a personal dashboard
View historical race Results

The participant dashboard provides access to relevant result information, including:

Race date
Event category
Official elapsed time
Finishing position

This separation of roles ensures that participants can manage their own information and registrations while event organisers retain control over the administrative functions of the platform.
