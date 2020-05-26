import {
  createApp,
} from "https://servestjs.org/@v1.1.0/mod.ts";

const app = createApp();

app.handle("/", async (req) => {
  await req.respond({
    status: 200,
    headers: new Headers({
      "content-type": "text/plain",
    }),
    body: "hello deno!",
  });
});

app.post("/deno", async(req) => {
  await req.respond({
    status: 200,
    headers: new Headers({
      "content-type": "application/json",
    }),
    body: JSON.stringify({
      deno: "land"
    }),
  })
})

app.listen({ port: 8808 });