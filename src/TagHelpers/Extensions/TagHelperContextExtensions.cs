/*
 * TagHelperContextExtensions.cs
 *
 *   Created: 2024-34-15T17:34:21-05:00
 *   Modified: 2024-34-15T17:34:21-05:00
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2024 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.TagHelpers.Extensions;

public static class TagHelperContextExtensions
{
    public static bool HasContextItem<T>(this TagHelperContext context)
    {
        return context.HasContextItem<T>(useInherited: true);
    }

    public static bool HasContextItem<T>(this TagHelperContext context, bool useInherited)
    {
        return context.HasContextItem(typeof(T), useInherited);
    }

    public static bool HasContextItem(this TagHelperContext context, Type type)
    {
        return context.HasContextItem(type, useInherited: true);
    }

    public static bool HasContextItem(this TagHelperContext context, Type type, bool useInherited)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        var contextItem = context.GetContextItem(type, useInherited);
        if (contextItem != null)
        {
            return type.IsInstanceOfType(contextItem);
        }
        return false;
    }

    public static bool HasContextItem<T>(this TagHelperContext context, string key)
    {
        return context.HasContextItem(typeof(T), key);
    }

    public static bool HasContextItem(this TagHelperContext context, Type type, string key)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        if (key == null)
        {
            throw new ArgumentNullException("key");
        }
        if (context.Items.ContainsKey(key))
        {
            return type.IsInstanceOfType(context.Items[key]);
        }
        return false;
    }

    public static T GetContextItem<T>(this TagHelperContext context) where T : class
    {
        return context.GetContextItem<T>(useInherited: true);
    }

    public static T GetContextItem<T>(this TagHelperContext context, bool useInherited) where T : class
    {
        return context.GetContextItem(typeof(T), useInherited) as T;
    }

    public static object GetContextItem(this TagHelperContext context, Type type)
    {
        return context.GetContextItem(type, useInherit: true);
    }

    public static T GetContextItem<T>(this TagHelperContext context, string key) where T : class
    {
        return context.GetContextItem(typeof(T), key) as T;
    }

    public static object GetContextItem(this TagHelperContext context, Type type, string key)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        if (key == null)
        {
            throw new ArgumentNullException("key");
        }
        if (!context.Items.ContainsKey(key) || !type.IsInstanceOfType(context.Items[key]))
        {
            return null;
        }
        return context.Items[key];
    }

    public static object GetContextItem(this TagHelperContext context, Type type, bool useInherit)
    {
        if (context.Items.ContainsKey(type))
        {
            return context.Items.First((KeyValuePair<object, object> kVP) => kVP.Key.Equals(type)).Value;
        }
        if (useInherit)
        {
            return context.Items.FirstOrDefault((KeyValuePair<object, object> kVP) => kVP.Key is Type && type.IsAssignableFrom((Type)kVP.Key)).Value;
        }
        return null;
    }

    public static void SetContextItem<T>(this TagHelperContext context, T contextItem)
    {
        context.SetContextItem(typeof(T), contextItem);
    }

    public static void SetContextItem(this TagHelperContext context, Type type, object contextItem)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        if (context.Items.ContainsKey(type))
        {
            context.Items[type] = contextItem;
        }
        else
        {
            context.Items.Add(type, contextItem);
        }
    }

    public static void SetContextItem(this TagHelperContext context, string key, object contextItem)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }
        if (key == null)
        {
            throw new ArgumentNullException("key");
        }
        if (context.Items.ContainsKey(key))
        {
            context.Items[key] = contextItem;
        }
        else
        {
            context.Items.Add(key, contextItem);
        }
    }

    public static void RemoveContextItem<T>(this TagHelperContext context)
    {
        context.RemoveContextItem<T>(useInherited: true);
    }

    public static void RemoveContextItem<T>(this TagHelperContext context, bool useInherited)
    {
        context.RemoveContextItem(typeof(T), useInherited);
    }

    public static void RemoveContextItem(this TagHelperContext context, Type type)
    {
        context.RemoveContextItem(type, useInherited: true);
    }

    public static void RemoveContextItem(this TagHelperContext context, Type type, bool useInherited)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        if (context.Items.ContainsKey(type))
        {
            context.Items.Remove(type);
        }
        else if (useInherited)
        {
            var keyValuePair = context.Items.FirstOrDefault((KeyValuePair<object, object> kVP) => kVP.Key is Type && ((Type)kVP.Key).IsAssignableFrom(type));
            if (!keyValuePair.Equals(default(KeyValuePair<object, object>)))
            {
                context.Items.Remove(keyValuePair);
            }
        }
    }

    public static void RemoveContextItem(this TagHelperContext context, string key)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }
        if (key == null)
        {
            throw new ArgumentNullException("key");
        }
        if (context.Items.ContainsKey(key))
        {
            context.Items.Remove(key);
        }
    }
}
