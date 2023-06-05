---
authors:
  - DGMJR-IO
title: Payloads
lastmod: 2023-04-21T10:12:28.174Z
created: 2023-03-31-11:30:03
project: AspNetCore
license: MIT
keywords:
  - http
  - payloads
  - httpresponse
categories:
  - http
slug: payloads
description: This package contains a set of classes that can be used to create HTTP requests and responses with various types of payloads along wirth a robut content type negotiation feature.
type: readme
---

# Payloads

This package contains a set of classes that can be used to create HTTP requests and responses with various types of payloads along wirth a robut content type negotiation feature.

## Use

The [Payload](https://github.com/dgmjr-io/Dgmjr.AspNetCore/blob/main/src/Payloads/Payload.cs) and [Payload&lt;T&gt;](https://github.com/dgmjr-io/Dgmjr.AspNetCore/blob/main/src/Payloads/Payload%7BT%7D.cs) classes as well as their subclasses should be used for receiving messages from the client.

Clients can request paged payloads by using the
