# E-commerce content review — 2026-09-10

Follow-up: hero updated using the built-in image tool and saved as `wwwroot/images/mobile-commerce/commerce-showcase-v3.png`. Edit prompt: "Edit only the subtitle text in this portfolio cover. Replace 'Customer app + owner app' with exactly 'Customer app + Shop owner app'. Preserve every other element, both phone screens, all UI content, title, background, composition and dimensions unchanged. Match the existing subtitle typography and center it."

Galleries now separate six shop-owner screens and four customer screens. CSS framing removes device bezels in thumbnails using per-image display bounds, without altering original screenshot pixels. Full originals remain available in the popup. Architecture connectors repaired; data access is explicitly in each app rather than a separate shared service.

Source: user-supplied `SklepInternetowyFinito.html` and its `images` directory. This is a project report, not runnable application source. Verification is documentary, not an execution test or security audit.

Supported: separate customer and owner apps; Kotlin; activities/fragments; RecyclerView; FireStoreClass; Firebase Authentication and password reset; Firestore records; Storage image uploads; Glide; catalog, cart totals, address management, order creation/history, product creation/deletion, and manually selectable order statuses. Polish/English support is stated in the report.

Removed unsupported narrative about a Java prototype evolving into this implementation, and claims of guaranteed stock/order synchronization. No payment gateway, transactional inventory guarantees, production readiness, or security guarantees are claimed. Existing repository link is retained but its code was not independently reviewed in this pass.

Original screens copied from the report: image3 (catalog), image10 (cart), image14 (product editor), image23 (order statuses). Profile/address screens and personal identifiers from the report are not included in the new assets. Existing unrelated assets were preserved.

## Generated assets

Built-in image-generation tool used, not CLI. Outputs are AI-assisted presentation composites, not literal screenshots. Original screenshots remain separately available on the page.

- `wwwroot/images/mobile-commerce/commerce-showcase-v2.png`
- `wwwroot/images/mobile-commerce/customer-flow-v2.png`

### Hero prompt

Create a polished wide 16:9 portfolio presentation composite for an academic Android e-commerce project. Use the two supplied screenshots as supporting compositing inputs: image 1 customer catalog, image 2 owner product editor. Keep the actual screen layouts and content faithful; do not redesign UI, invent features or add personal data. Display both upright phone screens clearly in a balanced professional dark charcoal composition with restrained pink-orange accents matching screenshots. Exact large title: "MOBILE E-COMMERCE". Subtitle: "Customer app + owner app". Small labels below the respective phones: "Browse products" and "Manage products". Small footer text: "Kotlin · Android · Firebase". Add a subtle cloud connector between phones to communicate shared backend. No extra screens, no performance claims, no payment provider logos. This is a presentation composite, not a new app UI. Save generated image.

### Customer flow prompt

Create a wide 16:9 dark charcoal portfolio presentation composite of these two actual Android screens. Image 1 is customer catalog, image 2 is shopping cart. Preserve their visible UI faithfully, no redesigned screens, no invented products or functionality, no personal information. Place upright phone screenshots side by side with generous whitespace, subtle pink-orange accents. Exact title: "CUSTOMER SHOPPING FLOW". Labels: "Browse the catalog" and "Review the cart". Modest arrow between phones. Small subtitle: "Products · Quantities · Order totals". Professional clean typography. No payment logos or promises. This is an illustrative presentation composite, not a literal app screenshot.
